using Microsoft.EntityFrameworkCore;
using ApiMyContabs.Repository.Entity;
using Npgsql;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Data;
using Newtonsoft.Json;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiMyContabs.Repository
{
    public class ConnectionContext : DbContext
    {
        public DbSet<UserModel> User { get; set; }
        public DbSet<Spender> Spender { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<UserBankAccountModel> UserBankAccount { get; set; }
        public DbSet<UserBillModel> UserBill { get; set; }
        public DbSet<UserInvestimentModel> UserInvestiment { get; set; }
        public DbSet<UserMetaModel> UserMeta { get; set; }
        public DbSet<ViewUserInvestiment> viewUserInvestiment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ViewUserInvestiment>(Entity =>
            {
                Entity.HasNoKey();
                Entity.ToView("view_user_investiment");
                Entity.Property(x => x.UserId).HasColumnName("UserId");
                Entity.Property(x => x.UserName).HasColumnName("UserName");
                Entity.Property(x => x.TotalInvestiment).HasColumnName("TotalInvestiment");
                Entity.Property(x => x.TotalBills).HasColumnName("TotalBills");
                Entity.Property(x => x.MetaDescription).HasColumnName("MetaDescription");
                Entity.Property(x => x.MetaValue).HasColumnName("MetaValue");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost; Database=MyContabs; Port=5433; User Id=postgres; Password=brendo;");
    
        public DbCommand CreateCommand()
        {
            var command = this.Database.GetDbConnection().CreateCommand();
            return command;
        }

        public void OpenConnection(DbCommand Command)
        {
            if(Command.Connection != null && Command.Connection.State != System.Data.ConnectionState.Open)
            {
                Command.Connection.Open();
            }
        }

        public void CloseConnection(DbCommand Command)
        {
            if (Command.Connection != null && Command.Connection.State != System.Data.ConnectionState.Closed)
            {
                Command.Connection.Close();
            }
        }

        public DbCommand AddParameters(DbCommand Command, Dictionary<string, object?> DParams)
        {
            foreach(KeyValuePair<string, object> param in DParams)
            {
                var Parameter = Command.CreateParameter();
                if (param.Value != null)
                {
                    Parameter.ParameterName = $"@{param.Key}";
                    Parameter.Value = param.Value;

                    DbType ParamType = GetParameterType(Parameter);

                    Parameter.DbType = ParamType;
                    Command.Parameters.Add(Parameter);
                }
            }

            return Command;
        } 

        public DbType GetParameterType(DbParameter parameter)
        {
            if (parameter.Value is int)
                parameter.DbType = DbType.Int32;
            else if (parameter.Value is string)
                parameter.DbType = DbType.String;
            else if (parameter.Value is DateTime)
                parameter.DbType = DbType.DateTime;
            else if (parameter.Value is bool)
                parameter.DbType = DbType.Boolean;
            else if (parameter.Value is double)
                parameter.DbType = DbType.Double;
            else
                parameter.DbType = DbType.Object;

            return parameter.DbType;
        }

        public Dictionary<string,object?> GetDictionaryFromObject(Object obj)
        {
            Dictionary<string, object?> Dparams = new Dictionary<string, object?>();

            PropertyInfo[] Properties = obj.GetType().GetProperties();
            
            foreach (PropertyInfo propertie in Properties)
            {
                object? value = propertie.GetValue(obj, null);
                if (value!=null)
                    Dparams[propertie.Name] = propertie.GetValue(obj, null);
            }

            return Dparams;
        }

        public string ExecuteReader(DbCommand Command)
        {
            try
            {
                OpenConnection(Command);
                using (var Reader = Command.ExecuteReader())
                {
                    var Result = new List<Dictionary<string, object>>();

                    while (Reader.Read())
                    {
                        var Row = new Dictionary<string, object>();

                        for (int index = 0; index < Reader.FieldCount; index++)
                        {
                            Row[Reader.GetName(index)] = Reader.GetValue(index).ToString().Trim();
                        }
                        Result.Add(Row);
                    }
                    return JsonConvert.SerializeObject(Result).Trim();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection(Command);
            }
        }
    }
}
