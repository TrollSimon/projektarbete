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
                int health = 0;
                int attack = 0;
                int speed = 0;
                int crit = 0;

                while (reader.Read())
                {
                    name = reader.GetString(0);

                    switch (reader.GetString(1))
                    {
                        case "Health":
                            health = reader.GetInt32(2);
                            break;
                        case "AttackPower":
                            attack = reader.GetInt32(2);
                            break;
                        case "Speed":
                            speed = reader.GetInt32(2);
                            break;
                        case "CriticalHitChance":
                            crit = reader.GetInt32(2);
                            break;
                    }
                }

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

                string sql = "SELECT Event.Description, EventChoice.Description, Target FROM Event LEFT JOIN EventChoice ON ID = Source WHERE ID = @id";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                string desc = null;
                List<Choice> choices = new List<Choice>();
                while (reader.Read())
                {
                    desc = reader.GetString(0);

                    try
                    {
                        choices.Add(new Choice(reader.GetString(1), reader.GetInt32(2)));
                    }
                    catch (Exception) { }
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
                int health = 0;
                int attack = 0;
                int speed = 0;
                int crit = 0;

                while (reader.Read())
                {
                    name = reader.GetString(0);
                    desc = reader.GetString(1);

                    switch (reader.GetString(2))
                    {
                        case "Health":
                            health = reader.GetInt32(3);
                            break;
                        case "AttackPower":
                            attack = reader.GetInt32(3);
                            break;
                        case "Speed":
                            speed = reader.GetInt32(3);
                            break;
                        case "CriticalHitChance":
                            crit = reader.GetInt32(3);
                            break;
                    }
                }

                item = new Item(name, desc, health, attack, speed, crit);

                connection.Close();
            }

            return item;
        }

    }
}
