﻿using RestWithASPNETFive.Models;
using RestWithASPNETFive.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETFive.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {

        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }


        public List<Person> FindAll()
        {

            return _context.Persons.ToList();
        }



        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) //Se metodo retorna false, cria-se uma person
                return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return person;


        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private bool Exists(long id)
        {
            //'Any' é para identificar se dentro do contexto (banco) existe QUALQUER (any) id que corresponda ao que passamos
            return _context.Persons.Any(p => p.Id.Equals(id));
            //Se tiver, vai retornar true e a gente pode prosseguir com o processo.
        }



    }
}
