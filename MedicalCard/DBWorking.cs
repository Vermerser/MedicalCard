using System;
using System.Collections;
using System.Data.SqlClient;

namespace MedicalCard
{
    // Класс для работы с базой данных
    class DBWorking
    {
        // строка подключения
        string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MedDB.mdf;Integrated Security=True";
        #region classVariables
        // структура для работы с таблицей User
        struct UserStruct
        {
            public int userID;
            public string userName;
            public string userSpeciality;
            public string userLogin;
            public string userPassword;
            public bool userDelStatus;
            public int userStatus;

            public UserStruct(int ID, string name, string spec, string login, string pass, bool delStat, int stat)
            {
                userID = ID;
                userName = name;
                userSpeciality = spec;
                userLogin = login;
                userPassword = pass;
                userDelStatus = delStat;
                userStatus = stat;
            }

            public override string ToString()
            {
                string sep = "$$$$$";
                return userID + sep + userName + sep + userSpeciality + sep + userLogin + 
                    sep + userPassword + sep + userDelStatus + sep + userStatus;
            }
        }

        // структура для работы с таблицей Pacient
        struct PacientStruct
        {
            public int pacID;
            public string pacName;
            public string pacAdres;
            public string pacTelephone;
            public int pacSex;
            public DateTime pacBirthDate;
            public string pacWorkPlace;
            public bool pacDelStatus;

            public PacientStruct(int ID, string name, string adres, string tel, int sex, DateTime bDate, 
                string workPl, bool delStat)
            {
                pacID = ID;
                pacName = name;
                pacAdres = adres;
                pacTelephone = tel;
                pacSex = sex;
                pacBirthDate = bDate;
                pacWorkPlace = workPl;
                pacDelStatus = delStat;
            }

            public override string ToString()
            {
                string sep = "$$$$$";
                return pacID + sep + pacName + sep + pacAdres + sep + pacTelephone +
                    sep + pacSex + sep + pacBirthDate + sep + pacWorkPlace + sep + 
                    pacDelStatus;
            }
        }
        // структура для работы с таблицей Anpmt_data
        struct AnpmtStruct
        {
            public DateTime anpmtDate;
            public float anpmtWeight;
            public float anpmtHeight;
            public string anpmtPressure;
            public int pacientID;
            public int userID;
            
            public AnpmtStruct(DateTime aDate, float weight, float height, string pressure, 
                int pacId, int userId)
            {
                anpmtDate = aDate;
                anpmtWeight = weight;
                anpmtHeight = height;
                anpmtPressure = pressure;
                pacientID = pacId;
                userID = userId;
            }

            public override string ToString()
            {
                string sep = "$$$$$";
                return anpmtDate + sep + anpmtWeight + sep + anpmtHeight +
                    sep + anpmtPressure + sep + pacientID + sep + userID;
            }
        }
        // структура для работы с таблицей Vaccinations
        struct VaccinStruct
        {
            public DateTime vaccinDate;
            public string vaccinName;
            public string vaccinDatch;
            public float vaccinDose;
            public string vaccinState;
            public int pacientID;
            public int userID;

            public VaccinStruct(DateTime aDate, string name, string datch, 
                float dose, string state, int pacId, int userId)
            {
                vaccinDate = aDate;
                vaccinName = name;
                vaccinDatch = datch;
                vaccinDose = dose;
                vaccinState = state;
                pacientID = pacId;
                userID = userId;
            }

            public override string ToString()
            {
                string sep = "$$$$$";
                return vaccinDate + sep + vaccinName + sep + vaccinDatch + sep + vaccinDose +
                    sep + vaccinState + sep + pacientID + sep + userID;
            }
        }
        // структура для работы с таблицей Dose_commitment
        struct DoseCommStruct
        {
            public int doseCommNumber;
            public DateTime doseCommDate;
            public string doseCommType;
            public float doseCommDose;
            public int pacientID;
            public int userID;

            public DoseCommStruct(int number, DateTime aDate, string type, 
                float dose, int pacId, int userId)
            {
                doseCommNumber = number;
                doseCommDate = aDate;
                doseCommType = type;
                doseCommDose = dose;
                pacientID = pacId;
                userID = userId;
            }

            public override string ToString()
            {
                string sep = "$$$$$";
                return doseCommNumber + sep + doseCommDate + sep + doseCommType + 
                    sep + doseCommDose + sep + pacientID + sep + userID;
            }
        }
        // структура для работы с таблицей Diagnose
        struct DiagnoseStruct
        {
            public DateTime diagnoseDate;
            public string diagnoseName;
            public bool diagnoseStatus;
            public int pacientID;
            public int userID;

            public DiagnoseStruct(DateTime aDate, string name, 
                bool status, int pacId, int userId)
            {
                diagnoseDate = aDate;
                diagnoseName = name;
                diagnoseStatus = status;
                pacientID = pacId;
                userID = userId;
            }

            public override string ToString()
            {
                string sep = "$$$$$";
                return diagnoseDate + sep + diagnoseName + sep + diagnoseStatus + 
                    sep + pacientID + sep + userID;
            }
        }
        // структура для работы с таблицей Temp_disability
        struct TempDisStruct
        {
            public string tempDisYear;
            public string tempDisReason;
            public string tempDisPeriod;
            public int tempDisCount;
            public int pacientID;
            public int userID;

            public TempDisStruct(string year, string reason, string period,
                int count, int pacId, int userId)
            {
                tempDisYear = year;
                tempDisReason = reason;
                tempDisPeriod = period;
                tempDisCount = count;
                pacientID = pacId;
                userID = userId;
            }

            public override string ToString()
            {
                string sep = "$$$$$";
                return tempDisYear + sep + tempDisReason + sep + tempDisPeriod + 
                    sep + tempDisCount + sep + pacientID + sep + userID;
            }
        }
        // структура для работы с таблицей Inspection
        struct InspectionStruct
        {
            public DateTime inspDate;
            public string inspResult;
            public string inspRecomendation;
            public int pacientID;
            public int userID;

            public InspectionStruct(DateTime aDay, string result, string recomendation,
                int pacId, int userId)
            {
                inspDate = aDay;
                inspResult = result;
                inspRecomendation = recomendation;
                pacientID = pacId;
                userID = userId;
            }

            public override string ToString()
            {
                string sep = "$$$$$";
                return inspDate + sep + inspResult + sep + inspRecomendation +
                    sep + pacientID + sep + userID;
            }
        }
        // структура для работы с таблицей Diagnostics
        struct DiagnosticsStruct
        {
            public DateTime diagDate;
            public string diagType;
            public string diagDiagnose;
            public string diagResult;
            public int pacientID;
            public int userID;

            public DiagnosticsStruct(DateTime aDay, string type, string diagnose,
                string result, int pacId, int userId)
            {
                diagDate = aDay;
                diagType = type;
                diagDiagnose = diagnose;
                diagResult = result;
                pacientID = pacId;
                userID = userId;
            }

            public override string ToString()
            {
                string sep = "$$$$$";
                return diagDate + sep + diagType + sep + diagDiagnose +
                    sep + diagResult + sep + pacientID + sep + userID;
            }
        }
        // структура для работы с таблицей Laboratory
        struct LaboratoryStruct
        {
            public DateTime labDate;
            public string labType;
            public int labNumber;
            public int pacientID;
            public int userID;

            public LaboratoryStruct(DateTime aDay, string type, int number,
                int pacId, int userId)
            {
                labDate = aDay;
                labType = type;
                labNumber = number;
                pacientID = pacId;
                userID = userId;
            }

            public override string ToString()
            {
                string sep = "$$$$$";
                return labDate + sep + labType + sep + labNumber +
                    sep + pacientID + sep + userID;
            }
        }
        #endregion

        // Функция чтения данных из таблиц User и Pacient базы данных
        public ArrayList ReadUserPacientData(string table)
        {
            string sqlExpression = $"SELECT * FROM [{table}]";
            // создание списка структур для записи данных из базы
            ArrayList resultList = new ArrayList();
            // создание подключения
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // открытие подключения
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчное считывание данных
                    {
                        if (table == "User")
                        {
                            resultList.Add(new UserStruct(reader.GetInt32(0), reader.GetString(1).Trim(), reader.GetString(2).Trim(), 
                                reader.GetString(3).Trim(), reader.GetString(4).Trim(), reader.GetBoolean(5), reader.GetInt32(6)));
                        }
                        if (table == "Pacient")
                        {
                            resultList.Add(new PacientStruct(reader.GetInt32(0), reader.GetString(1).Trim(), reader.GetString(2).Trim(),
                                reader.GetString(3).Trim(), reader.GetInt32(4), reader.GetDateTime(5), reader.GetString(6).Trim(), 
                                reader.GetBoolean(7)));
                        }
                    }
                }

                reader.Close();
            }
            return resultList;
        }

        // Функция чтения из таблиц Anpmt_data, Diagnose, Diagnostics, Dose_commitment
        // Inspection, Laboratory, Temp_disability, Vaccinations базы данных
        public ArrayList ReadOthersData(string table, int ID)
        {
            string sqlExpression = $"SELECT * FROM [{table}] WHERE pacient_id ='{ID}'";
            // создание списка структур для записи данных из базы
            ArrayList resultList = new ArrayList();
            // создание подключения
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // открытие подключения
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчное считывание данных
                    {
                        if (table == "Anpmt_data")
                        {
                            resultList.Add(new AnpmtStruct(reader.GetDateTime(0), reader.GetFloat(1), reader.GetFloat(2), 
                                reader.GetString(3).Trim(), reader.GetInt32(4), reader.GetInt32(5)));
                        }
                        else if (table == "Vaccinations")
                        {
                            resultList.Add(new VaccinStruct(reader.GetDateTime(0), reader.GetString(1).Trim(), 
                                reader.GetString(2).Trim(), reader.GetFloat(3), reader.GetString(4).Trim(), 
                                reader.GetInt32(5), reader.GetInt32(6)));
                        }
                        else if (table == "Dose_commitment")
                        {
                            resultList.Add(new DoseCommStruct(reader.GetInt32(0), reader.GetDateTime(1), 
                                reader.GetString(2).Trim(), reader.GetFloat(3), reader.GetInt32(4), reader.GetInt32(5)));
                        }
                        else if (table == "Diagnose")
                        {
                            resultList.Add(new DiagnoseStruct(reader.GetDateTime(0), reader.GetString(1).Trim(), 
                                reader.GetBoolean(2), reader.GetInt32(3), reader.GetInt32(4)));
                        }
                        else if (table == "Temp_disability")
                        {
                            resultList.Add(new TempDisStruct(reader.GetString(0).Trim(), reader.GetString(1).Trim(),
                                reader.GetString(2).Trim(), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5)));
                        }
                        else if (table == "Inspection")
                        {
                            resultList.Add(new InspectionStruct(reader.GetDateTime(0), reader.GetString(1).Trim(),
                                reader.GetString(2).Trim(), reader.GetInt32(3), reader.GetInt32(4)));
                        }
                        else if (table == "Diagnostics")
                        {
                            resultList.Add(new DiagnosticsStruct(reader.GetDateTime(0), reader.GetString(1).Trim(),
                                reader.GetString(2).Trim(), reader.GetString(3).Trim(), reader.GetInt32(4), reader.GetInt32(5)));
                        }
                        else if (table == "Laboratory")
                        {
                            resultList.Add(new LaboratoryStruct(reader.GetDateTime(0), reader.GetString(1).Trim(),
                                reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4)));
                        }
                    }
                }
                reader.Close();
            }
            return resultList;
        }

        // Функция получения имени пользователя по его ID
        public string ReadUserName(int ID)
        {
            string userName = "";
            string sqlExpression = $"SELECT * FROM [User] WHERE user_id ='{ID}'";
            // создание подключения
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // открытие подключения
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    reader.Read();
                    userName = reader.GetString(1).Trim();
                }
                reader.Close();
            }
            return userName;
        }

        // Функция вставки данных в таблицу User базы данных
        public int AddDataInUserTable(int ID, string name, string spec, string login, string pass, bool delStat, int stat)
        {
            int number; // число добавленных в таблицу объектов
            string columns = "user_id, user_name, user_specialty, user_login, user_password, user_del_status, user_status";
            string sqlExpression = $"INSERT INTO [User] ({columns}) " +
                                   $"VALUES ({ID}, N'{name}', N'{spec}', '{login}', '{pass}', '{delStat}', {stat})";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                number = command.ExecuteNonQuery();
            }
            return number;
        }

        // Функция вставки данных в таблицу Pacient базы данных
        public int AddDataInPacientTable(int ID, string name, string adres, string telephone, int sex,
            DateTime birthDate, string workPlace, bool delStat)
        {
            int number; // число добавленных в таблицу объектов
            string columns = "pacient_id, pacient_name, pacient_adres, pacient_telephone, pacient_sex, pacient_birth_date, " +
                             "pacient_work_place, pacient_del_status";
            string sqlExpression = $"INSERT INTO [Pacient] ({columns}) " +
                                   "VALUES (@ID, @Name, @Adres, @Telephone, @Sex, @BirthDate, @WorkPlace, @DelStat)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // параметры
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Adres", adres);
                command.Parameters.AddWithValue("@Telephone", telephone);
                command.Parameters.AddWithValue("@Sex", sex);
                command.Parameters.AddWithValue("@BirthDate", birthDate);
                command.Parameters.AddWithValue("@WorkPlace", workPlace);
                command.Parameters.AddWithValue("@DelStat", delStat);

                connection.Open();
                number = command.ExecuteNonQuery();
            }
            return number;
        }

        // Функция вставки данных в таблицу Anpmt_data базы данных
        public int AddDataInAnpmtTable(DateTime aDate, float weight, float height,
            string pressure, int pacientId, int userId)
        {
            int number; // число добавленных в таблицу объектов
            string columns = "anpmt_data_date, anpmt_data_weight, anpmt_data_height, " +
                             "anpmt_data_pressure, pacient_id, user_id";
            string sqlExpression = $"INSERT INTO [Anpmt_data] ({columns}) " +
                                   "VALUES (@Date, @Weight, @Height, @Pressure, @PacientId, @UserId)";

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // параметры
                command.Parameters.AddWithValue("@Date", aDate);
                command.Parameters.AddWithValue("@Weight", weight);
                command.Parameters.AddWithValue("@Height", height);
                command.Parameters.AddWithValue("@Pressure", pressure);
                command.Parameters.AddWithValue("@PacientId", pacientId);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                number = command.ExecuteNonQuery();
            }
            return number;
        }

        // Функция вставки данных в таблицу Vaccinations базы данных
        public int AddDataInVaccinationsTable(DateTime aDate, string name, string batch, float dose,
            string state, int pacientId, int userId)
        {
            int number; // число добавленных в таблицу объектов
            string columns = "vaccinations_date, vaccinations_name, vaccinations_batch, " +
                             "vaccinations_dose, vaccinations_state, pacient_id, user_id";
            string sqlExpression = $"INSERT INTO [Vaccinations] ({columns}) " +
                                   "VALUES (@Date, @Name, @Batch, @Dose, @State, @PacientId, @UserId)";

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // параметры
                command.Parameters.AddWithValue("@Date", aDate);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Batch", batch);
                command.Parameters.AddWithValue("@Dose", dose);
                command.Parameters.AddWithValue("@State", state);
                command.Parameters.AddWithValue("@PacientId", pacientId);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                number = command.ExecuteNonQuery();
            }
            return number;
        }

        // Функция вставки данных в таблицу Dose_commitment базы данных
        public int AddDataInDoseCommitmentTable(int num, DateTime aDate, string type, float dose,
            int pacientId, int userId)
        {
            int number; // число добавленных в таблицу объектов
            string columns = "dose_commitment_number, dose_commitment_date, dose_commitment_type, " +
                             "dose_commitment_dose, pacient_id, user_id";
            string sqlExpression = $"INSERT INTO [Dose_commitment] ({columns}) " +
                                   "VALUES (@Number, @Date, @Type, @Dose, @PacientId, @UserId)";

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // параметры
                command.Parameters.AddWithValue("@Number", num);
                command.Parameters.AddWithValue("@Date", aDate);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Dose", dose);
                command.Parameters.AddWithValue("@PacientId", pacientId);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                number = command.ExecuteNonQuery();
            }
            return number;
        }

        // Функция вставки данных в таблицу Diagnose базы данных
        public int AddDataInDiagnoseTable(DateTime aDate, string name, bool status,
            int pacientId, int userId)
        {
            int number; // число добавленных в таблицу объектов
            string columns = "diagnose_date, diagnose_name, diagnose_status, " +
                             "pacient_id, user_id";
            string sqlExpression = $"INSERT INTO [Diagnose] ({columns}) " +
                                   "VALUES (@Date, @Name, @Status, @PacientId, @UserId)";

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // параметры
                command.Parameters.AddWithValue("@Date", aDate);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@PacientId", pacientId);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                number = command.ExecuteNonQuery();
            }
            return number;
        }

        // Функция вставки данных в таблицу Temp_disability базы данных
        public int AddDataInTempDisTable(string year, string reason, string period,
            int count, int pacientId, int userId)
        {
            int number; // число добавленных в таблицу объектов
            string columns = "temp_disability_year, temp_disability_reason, temp_disability_period, " +
                             "temp_disability_count, pacient_id, user_id";
            string sqlExpression = $"INSERT INTO [Temp_disability] ({columns}) " +
                                   "VALUES (@Year, @Reason, @Period, @Count, @PacientId, @UserId)";

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // параметры
                command.Parameters.AddWithValue("@Year", year);
                command.Parameters.AddWithValue("@Reason", reason);
                command.Parameters.AddWithValue("@Period", period);
                command.Parameters.AddWithValue("@Count", count);
                command.Parameters.AddWithValue("@PacientId", pacientId);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                number = command.ExecuteNonQuery();
            }
            return number;
        }

        // Функция вставки данных в таблицу Inspection базы данных
        public int AddDataInInspTable(DateTime aDate, string result, string recomendation,
            int pacientId, int userId)
        {
            int number; // число добавленных в таблицу объектов
            string columns = "inspection_date, inspection_result, inspection_recomendation, " +
                             "pacient_id, user_id";
            string sqlExpression = $"INSERT INTO [Inspection] ({columns}) " +
                                   "VALUES (@Day, @Result, @Recomendation, @PacientId, @UserId)";

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // параметры
                command.Parameters.AddWithValue("@Day", aDate);
                command.Parameters.AddWithValue("@Result", result);
                command.Parameters.AddWithValue("@Recomendation", recomendation);
                command.Parameters.AddWithValue("@PacientId", pacientId);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                number = command.ExecuteNonQuery();
            }
            return number;
        }

        // Функция вставки данных в таблицу Diagnostics базы данных
        public int AddDataInDiagnosticsTable(DateTime aDate, string type, string diagnose,
            string result, int pacientId, int userId)
        {
            int number; // число добавленных в таблицу объектов
            string columns = "diagnostics_date, diagnostics_type, diagnostics_diagnose, " +
                             "diagnostics_result, pacient_id, user_id";
            string sqlExpression = $"INSERT INTO [Diagnostics] ({columns}) " +
                                   "VALUES (@Day, @Type, @Diagnose, @Result, @PacientId, @UserId)";

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // параметры
                command.Parameters.AddWithValue("@Day", aDate);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Diagnose", diagnose);
                command.Parameters.AddWithValue("@Result", result);
                command.Parameters.AddWithValue("@PacientId", pacientId);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                number = command.ExecuteNonQuery();
            }
            return number;
        }

        // Функция вставки данных в таблицу Laboratory базы данных
        public int AddDataInLaboratoryTable(DateTime aDate, string type, int num,
            int pacientId, int userId)
        {
            int number; // число добавленных в таблицу объектов
            string columns = "laboratory_date, laboratory_type, laboratory_number, " +
                             "pacient_id, user_id";
            string sqlExpression = $"INSERT INTO [Laboratory] ({columns}) " +
                                   "VALUES (@Day, @Type, @Number, @PacientId, @UserId)";

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // параметры
                command.Parameters.AddWithValue("@Day", aDate);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Number", num);
                command.Parameters.AddWithValue("@PacientId", pacientId);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                number = command.ExecuteNonQuery();
            }
            return number;
        }

        // Функция обновления данных в таблице User
        public int EditDataInUserTable(int ID, string name, string spec, string login, string pass, bool delStat, int stat)
        {
            int number; // число обновленных в таблице объектов
            string sqlExpression = $"UPDATE [User] SET user_name = N'{name}', user_specialty = N'{spec}', user_login = '{login}', " +
                                   $"user_password = '{pass}', user_del_status = '{delStat}', user_status = {stat} WHERE user_id ='{ID}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                number = command.ExecuteNonQuery();
            }

            return number;
        }

        // Функция обновления данных в таблице Pacient
        public int EditDataInPacientTable(int ID, string name, string adres, string tel, int sex, DateTime birthDate, string workPlace, bool delStat)
        {
            int number; // число обновленных в таблице объектов
            string sqlExpression =
                "UPDATE [Pacient] SET pacient_name = @Name, pacient_adres = @Adres, pacient_telephone = @Tel, pacient_sex = @Sex, " +
                "pacient_birth_date = @BirthDate, pacient_work_place = @WorkPlace, pacient_del_status = @DelStat WHERE pacient_id =@ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // параметры
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Adres", adres);
                command.Parameters.AddWithValue("@Tel", tel);
                command.Parameters.AddWithValue("@Sex", sex);
                command.Parameters.AddWithValue("@BirthDate", birthDate);
                command.Parameters.AddWithValue("@WorkPlace", workPlace);
                command.Parameters.AddWithValue("@DelStat", delStat);

                connection.Open();
                number = command.ExecuteNonQuery();
            }
            return number;
        }

        // Функция удаления данных из таблиц User
        public int DelDataFromUserTable(int delID)
        {
            int number; // число удаленных из таблицы объектов
            string sqlExpression = $"DELETE FROM [User] WHERE user_id = '{delID}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                number = command.ExecuteNonQuery();
            }
            return number;
        }

        // Функция удаления пациента (изменение статуса активности)
        public int UpdatePacientInTable(int delID, bool status)
        {
            int number; // число обновленных в таблице объектов
            string sqlExpression = $"UPDATE [Pacient] SET pacient_del_status = '{status}' WHERE pacient_id ='{delID}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                number = command.ExecuteNonQuery();
            }
            return number;
        }
    }
}