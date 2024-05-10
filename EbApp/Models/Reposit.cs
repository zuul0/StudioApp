﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;

namespace EbApp.Models
{
    public class Reposit
    {
        public SQLiteConnection database;
        public Reposit(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Trainer>();
            database.CreateTable<Client>();
            database.CreateTable<Appointment>();
            database.CreateTable<ScheduleClient>();
            AddDefaultTrainers();
        }


        // Клиенты
        public void AddClient(Client newClient)
        {
            database.Insert(newClient);
        }

        public void UpdateClient(Client updatedClient)

        { database.Update(updatedClient); }


        public  Client GetClientById(int clientId)
        {
            return database.Table<Client>().FirstOrDefault(c => c.IdClient == clientId);
        }
        //Метод для получения списка занятий, на которые записан клиент
        public List<Appointment> GetAppointmentsForClient(int clientId)
        {
            var scheduleEntries = database.Table<ScheduleClient>().Where(s => s.IdClient == clientId).ToList();
            var appointments = new List<Appointment>();

            foreach (var entry in scheduleEntries)
            {
                var appointment = database.Get<Appointment>(entry.IdClass);
                appointments.Add(appointment);
            }

            return appointments;
        }


        //Тренеры


        private void AddDefaultTrainers()
        {
            var trainer1 = new Trainer
            {
                FirstName = "John",
                LastName = "Doe",
                MiddleName = "Smith",
                PhoneNumber = "1234567890",
                Direction = "Fitness",
                Photo = null
            };

            var trainer2 = new Trainer
            {
                FirstName = "Jane",
                LastName = "Doe",
                MiddleName = "Johnson",
                PhoneNumber = "0987654321",
                Direction = "Yoga",
                Photo = null
            };

            AddTrainer(trainer1);
            AddTrainer(trainer2);
        }

       

        public IEnumerable<Trainer> GetTrainers()
        {
            return database.Table<Trainer>().ToList();
        }

        public Trainer GetTrainer(int id)
        {
            return database.Get<Trainer>(id);
        }

        public List<string> GetAllDirections()
        {
            List<Trainer> trainers = database.Table<Trainer>().ToList();
            List<string> directions = new List<string>();

            foreach (Trainer Trainer in trainers)
            {
                if (Trainer != null)
                {
                    directions.Add(Trainer.Direction);
                }
            }

            return directions;
        }
        public string GetDirection(int id)
        {
            Trainer Trainer = database.Get<Trainer>(id);
            if (Trainer != null)
            {
                return Trainer.Direction;
            }
            else
            {
                return null;
            }
        }

        public void AddTrainer(Trainer trainer)
        {
            database.Insert(trainer);
        }

        public void UpdateTrainer(Trainer trainer)
        {
            database.Update(trainer);
        }

        public int DeleteTrainer(int id)
        {
            return database.Delete<Trainer>(id);
        }

        public int SaveTrainer(Trainer Trainer)
        {
            if (Trainer.Id != 0)
            {
                database.Update(Trainer);
                return Trainer.Id;
            }
            else
            {
                return database.Insert(Trainer);
            }
        }




        //Расписание
        public IEnumerable<Appointment> GetAppointments()
        {
            return database.Table<Appointment>().ToList();
        }

        public Appointment GetAppointment(int id)
        {
            return database.Get<Appointment>(id);
        }
        public int SaveAppointment(Appointment Client)
        {
            if (Client.Id != 0)
            {
                database.Update(Client);
                return Client.Id;
            }
            else
            {
                return database.Insert(Client);
            }
        }



        //Записи 

        public IEnumerable<ScheduleClient> GetScheduleEntriesForClass(int idClass)
        {
            return database.Table<ScheduleClient>().Where(s => s.IdClass == idClass).ToList();
        }
        //Метод для проверки наличия записи в таблице расписания
        public bool CheckScheduleEntry(int idClient, int idClass)
        {
            return database.Table<ScheduleClient>().Any(s => s.IdClient == idClient && s.IdClass == idClass);
        }
        //Метод для удаления записи из таблицы расписания для определенного клиента и занятия
        public void DeleteScheduleEntryForClient(int idClient, int idClass)
        {
            var entry = database.Table<ScheduleClient>().FirstOrDefault(s => s.IdClient == idClient && s.IdClass == idClass);
            if (entry != null)
            {
                database.Delete(entry);
            }
        }

        public IEnumerable<ScheduleClient> GetSchedules()
        {
            return database.Table<ScheduleClient>().ToList();
        }

        //для получения подробной информации о конкретном расписании
        public ScheduleClient GetSchedule(int id)
        {
            return database.Get<ScheduleClient>(id);
        }


        //еобходим для удаления расписаний, например, когда клиент отменяет бронирование.
        public int DeleteSchedule(int id)
        {
            return database.Delete<ScheduleClient>(id);
        }

        //сохраняет или обновляет запись в таблице ScheduleClient
        //метод нужен для сохранения новых расписаний или изменения существующих
        public int SaveClient(ScheduleClient ScheduleClient)
        {
            if (ScheduleClient.Id != 0)
            {
                database.Update(ScheduleClient);
                return ScheduleClient.IdClient;
            }
            else
            {
                return database.Insert(ScheduleClient);
            }
        }


        //public int LSaveItem(List item)
        //{
        //    if (item.IDList != 0)
        //    {
        //        database.Update(item);
        //        return item.IDList;
        //    }
        //    else
        //    {
        //        return database.Insert(item);
        //    }
        //}
    }
}
