using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost, 1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            ReadUsersWithRoles(connection);
            //CreateUser(connection);
            // ReadRoles(connection);
            // ReadTags(connection);
            //DeleteRole(connection);
            //UpdateRole(connection);
            //UpdateUser(connection);
            //DeleteUser(connection);
            //ReadUser();
            //CreateUser();
            //UpdateUser();
            //DeleteUser();
            connection.Close();

        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);

        }
        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }
        }

        public static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Email = "haiaiah@gmail.com",
                Bio = "bio",
                Image = "imagem",
                Name = "Name",
                PasswordHash = "hash",
                Slug = "Slug"
            };
            var repository = new Repository<User>(connection);
            repository.Create(user);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }
        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        // --------------------------------------------------------------------------------------------

        public static void UpdateUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var user = repository.Get(1);
            user.Name = "Hailander Bastos";
            repository.Update(user);

        }

        public static void DeleteUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var user = repository.Get(1);
            repository.Delete(user);

        }

        public static void UpdateRole(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var role = repository.Get(1);
            role.Name = "Author Att";
            repository.Update(role);

        }

        public static void DeleteRole(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var role = repository.Get(1);
            repository.Delete(role);

        }


    }
}