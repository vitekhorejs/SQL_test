﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SQL_test
{
    public class TodoItemDatabase
    {
        private SQLiteAsyncConnection database;
        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
        }
        public Task<List<TodoItem>> GetItemsAsync()
        {
            return database.Table<TodoItem>().ToListAsync();
        }

        public Task<TodoItem> GetItemAsync(string ISBN)
        {
            return database.Table<TodoItem>().Where(i => i.ISBN == ISBN).FirstOrDefaultAsync();
        }

        /*public Task<List<TodoItem>> GetItemAsync(string value) ////////////////////////////////////////////////////////////////
        {
            if(value == "" || value == null)
            {
                return database.Table<TodoItem>().ToListAsync();
            }
            bool m = Regex.IsMatch(value, @"\d");
            //return database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }*/

        public Task<int> SaveItemAsync(TodoItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(TodoItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}
