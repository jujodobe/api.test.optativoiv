﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using infraestructure.Models;

namespace infraestructure.Repository
{
    public class PersonaRepository
    {
        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public PersonaRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this.connection = new Npgsql.NpgsqlConnection(this._connectionString);
        }

        public string insertarPersona(PersonaModel persona)
        {
            try
            {
                connection.Execute("insert into persona(nombre, apellido, edad, email, telefono) " +
                    " values(@nombre, @apellido, @edad, @email, @telefono)", persona);
                return "Se inserto correctamente...";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string modificarPersona(PersonaModel persona, int id) {
            try
            {
                connection.Execute($"UPDATE persona SET " +
                    "nombre = @nombre, " +
                    "apellido = @apellido, " +
                    "edad = @edad, " +
                    "email = @email, " +
                    "telefono = @telefono " +
                    $"WHERE id = {id}");
                return "Se modificaron los datos correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string eliminarPersona(int id)
        {
            try
            {
                connection.Execute($" DELETE FROM persona WHERE id = {id}");
                return "Se eliminó correctamente el registro...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PersonaModel consultarPersona(int id)
        {
            try
            {
               return connection.QueryFirst<PersonaModel>($"SELECT * FROM persona WHERE id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<PersonaModel> listarPersona()
        {
            try
            {
                return connection.Query<PersonaModel>($"SELECT * FROM persona order by id asc");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
