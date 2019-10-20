#File to move data from txt file to postgress db
import psycopg2
from config import config

def connect():
    conn = None
    try:
        params = config()

        print("Connecting to PostgreSQL database...")
        conn = psycopg2.connect(**params)

        cur = conn.cursor()

        print("PostgreSQL database version: ")
        cur.execute("SELECT * from \"Products\"")

        db_version = cur.fetchone()
        print(db_version)

        cur.close()
    except(Exception, psycopg2.DatabaseError) as error:
        print(error)

def ReadFile():
    filepath = input("Enter the path of the file to import from: ")
    if filepath=="":
        print("Missing file path")
        return
    
    file=open(filepath, "r")
    for line in file:
        col = line.split()
        print(col[0])

if __name__ =='__main__':
    connect()
    ReadFile()

