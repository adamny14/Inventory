#File to move data from txt file to postgress db
import psycopg2
from config import config
from multiprocessing import Pool
import time
from itertools import product

class DBData:
    def __init__(self):
        params = config()

        print("Connecting to PostgreSQL database...")
        self.conn = psycopg2.connect(**params)

        self.cur = self.conn.cursor()
        print("\x1b[1;32m"+"Connection Successful \x1b[1;0m")
        self.filepath = input("Enter the path of the file to import from: ")

        print("Beginning Uploading data to DB")
        self.start=time.time()
        
    def connect(self):
        try:                                
            self.ReadFile(self.filepath)
            print("Finished uploading data to DB: ",time.time()-self.start)
            self.cur.close()
        except(Exception, psycopg2.DatabaseError) as error:
            print(error)

    def ReadFile(self, filepath):
        if filepath=="":
            print("Missing file path")
            return
        
        file=open(self.filepath, "r")
        pool=Pool()
        results=pool.map(self, ReadLines, [line for line in file])
        

    def ReadLines(self, line):
        lineArr = line.split()
        sql="Insert into \"Products\"(\"Name\", \"Location\", \"Date_Purchased\", \"Quantity\", \"Type\", \"Photo\", \"Color\", \"Company\")"
        sql+=" VALUES(%s,%s,%s,%s,%s,%s,%s,%s)"
        self.cur.execute(lineArr[1],lineArr[2],lineArr[3],lineArr[4],lineArr[5],psycopg2.Binary(lineArr[6]),lineArr[7],lineArr[8])
        self.conn.commit()

        
if __name__ =='__main__':
    db = DBData()
    db.connect()

#C:\Users\adama\Documents\invintory.txt