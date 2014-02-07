using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbete.Data
{
    static class DataStore
    {
        public static Character GetCharacter(int id)
        {
            Character character = null;

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                connection.Open();

                string sql = "SELECT Name, Stat, Amount FROM Character INNER JOIN CharacterStats ON ID = Character WHERE ID = @id";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                string name = null;
                Dictionary<string, int> stats = new Dictionary<string, int>(); 
                while (reader.Read())
                {
                    name = reader.GetString(0);
                    stats.Add(reader.GetString(1), reader.GetInt32(2));
                }

                int health = (stats.ContainsKey("Health") ? stats["Health"] : 0);
                int attack = (stats.ContainsKey("AttackPower") ? stats["AttackPower"] : 0);
                int speed = (stats.ContainsKey("Speed") ? stats["Speed"] : 0);
                int crit = (stats.ContainsKey("CriticalHitChance") ? stats["CriticalHitChance"] : 0);
                character = new Character(name, health, attack, speed, crit);

                connection.Close();
            }

            return character;
        }

        public static Event GetEvent(int id)
        {
            Event evnt = null;

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                connection.Open();

                string sql = "SELECT Event.Description, EventChoice.Description, Target FROM Event INNER JOIN EventChoice ON ID = Source WHERE ID = @id";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                string desc = null;
                List<Choice> choices = new List<Choice>();
                while (reader.Read())
                {
                    desc = reader.GetString(0);
                    choices.Add(new Choice(reader.GetString(1), reader.GetInt32(2)));
                }

                evnt = new Event(desc, choices);

                connection.Close();
            }

            return evnt;
        }

        public static Item GetItem(int id)
        {
            Item item = null;

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                connection.Open();

                string sql = "SELECT Name, Description, Stat, Amount FROM Item INNER JOIN ItemStats ON ID = Item WHERE ID = @id";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                string name = null;
                string desc = null;
                Dictionary<string, int> stats = new Dictionary<string, int>();
                while (reader.Read())
                {
                    name = reader.GetString(0);
                    desc = reader.GetString(1);
                    stats.Add(reader.GetString(2), reader.GetInt32(3));
                }

                int health = (stats.ContainsKey("Health") ? stats["Health"] : 0);
                int attack = (stats.ContainsKey("AttackPower") ? stats["AttackPower"] : 0);
                int speed = (stats.ContainsKey("Speed") ? stats["Speed"] : 0);
                int crit = (stats.ContainsKey("CriticalHitChance") ? stats["CriticalHitChance"] : 0);
                item = new Item(name, desc, health, attack, speed, crit);

                connection.Close();
            }

            return item;
        }

    }
}
