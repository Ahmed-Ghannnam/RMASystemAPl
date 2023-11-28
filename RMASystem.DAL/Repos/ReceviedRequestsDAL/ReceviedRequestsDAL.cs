//using RMASystem.DAL;
//using System.Data.SqlClient;
//using RMASystem.DAL;


//namespace RMASystem.DAL
//{
//    //Table Name (API_RECEIVED_REQUESTS)
//    public class APIReceivedRequests
//    {
//        private const string fileLogSource = "API_RECEIVED_REQUEST";

//        #region Commands
//        private const string selectCommandText = "SELECT " +
//            "  [REQUEST_ID]" +
//            ", [BODY]" +
//            ", [RECEIVED_DATE]" +
//            ", [USER_NAME]" +
//            ", [API_TYPE]" +
//            ", [API_URI]" +
//            ", [REQUEST_METHOD]" +
//            " FROM [API_RECEIVED_REQUEST]";

//        private const string insertCommandText = "INSERT INTO API_RECEIVED_REQUEST ( BODY,  RECEIVED_DATE,  USER_NAME,  API_TYPE,  API_URI,  REQUEST_METHOD)" +
//                                                " OUTPUT inserted.REQUEST_ID" +
//                                                " VALUES (@BODY, @RECEIVED_DATE, @USER_NAME, @API_TYPE, @API_URI, @REQUEST_METHOD)";

//        private const string updateCommandText = "UPDATE API_RECEIVED_REQUEST " +
//                "SET [BODY] = @BODY" +
//                ", [RECEIVED_DATE] = @RECEIVED_DATE" +
//                ", [USER_NAME] = @USER_NAME" +
//                ", [API_TYPE] = @API_TYPE" +
//                ", [API_URI] = @API_URI" +
//                ", [REQUEST_METHOD] = @REQUEST_METHOD" +
//                " WHERE [REQUEST_ID] = @REQUEST_ID";
//        #endregion

//        #region Constructors
//        public APIReceivedRequests()
//        {
//        }
//        //public APIReceivedRequestsRepository(SqlConnection connection)
//        //{
//        //    _connection = connection;
//        //}
//        #endregion

//        #region Private Fields
//        private int _REQUEST_ID;
//        private string _BODY;
//        private DateTime _RECEIVED_DATE;
//        private string _USER_NAME;
//        private int _API_TYPE;
//        private string _API_URI;
//        private string _REQUEST_METHOD;
//        //private readonly SqlConnection _connection;
//        #endregion

//        #region Public Properties
//        public int REQUEST_ID
//        {
//            get { return _REQUEST_ID; }
//            //set { _REQUEST_ID = value; }
//        }
//        public string BODY
//        {
//            get { return _BODY; }
//            set { _BODY = value; }
//        }
//        public DateTime RECEIVED_DATE
//        {
//            get { return _RECEIVED_DATE; }
//            set { _RECEIVED_DATE = value; }
//        }
//        public string USER_NAME
//        {
//            get { return _USER_NAME; }
//            set { _USER_NAME = value; }
//        }
//        public API_TYPE API_TYPE
//        {
//            get { return (API_TYPE)_API_TYPE; }
//            //set { _API_TYPE = (int)value; }
//        }
//        public string API_URI
//        {
//            get { return _API_URI; }
//            set
//            {
//                _API_URI = value;
//                if (_API_URI.Contains("api/Account/ChangePassword"))
//                    _API_TYPE = (int)API_TYPE.CHANGE_PASSWORD;
//                else if (_API_URI.Contains("api/Account/Register"))
//                    _API_TYPE = (int)API_TYPE.REGISTER;
//                else if (_API_URI.Contains("Connect/Token"))
//                    _API_TYPE = (int)API_TYPE.GET_TOKEN;
//                else if (_API_URI.Contains("api/Customer/retail_customer_points"))
//                    _API_TYPE = (int)API_TYPE.GET_RETAIL_CUSTOMER_POINTS;
//                else if (_API_URI.Contains("api/Customer/retail_customer"))
//                    _API_TYPE = (int)API_TYPE.CREATE_UPDATE_RETAIL_CUSTOMER;
//                //else if (_API_URI.Contains("api/Article/CreateOrUpdateArticles"))
//                //    _API_TYPE = (int)API_TYPE.CREATE_ARTICLE;
//                //else if (_API_URI.Contains("api/Article/GetProductsInfo"))
//                //    _API_TYPE = (int)API_TYPE.GET_PRODUCT_INFO;
//                //else if (_API_URI.Contains("/api/Article/UpdateProductAsSynced"))
//                //    _API_TYPE = (int)API_TYPE.UPDATE_PRODUCT_AS_SYNCED;
//            }
//        }


//        public string REQUEST_METHOD
//        {
//            get { return _REQUEST_METHOD; }
//            set { _REQUEST_METHOD = value; }
//        }
//        #endregion

//        #region Select
//        public void GetAPI_RECEIVED_REQUEST()
//        {
//            SqlConnection con = new SqlConnection();
//            ConnectionDAL.OpenConnection(ref con);
//            SqlCommand com = con.CreateCommand();
//            com.CommandText = selectCommandText;
//            AssignReaderValues(com);
//            com.Dispose();
//            ConnectionDAL.CloseConnection(ref con);
//        }

//        #endregion

//        #region Insert
//        public void InsertAPI_RECEIVED_REQUEST()
//        {
//            SqlConnection con = new SqlConnection();
//            try
//            {
//                ConnectionDAL.OpenConnection(ref con);
//                SqlCommand com = con.CreateCommand();
//                com.CommandText = insertCommandText;
//                AddParameters(com);

//                SqlDataReader rd = com.ExecuteReader();
//                if (rd.Read() && rd.HasRows)
//                {
//                    this._REQUEST_ID = rd["REQUEST_ID"].To<int>();
//                }
//                com.Dispose();
//            }
//            catch (Exception ex)
//            {
//                // Log the exception
//                Console.WriteLine($"Error inserting into API_RECEIVED_REQUEST: {ex.Message}");
//            }
//            finally
//            {
//                ConnectionDAL.CloseConnection(ref con);
//            }
//        }

//        #endregion

//        #region Update
//        public void UpdateAPI_RECEIVED_REQUEST()
//        {
//            SqlConnection con = new SqlConnection();
//            ConnectionDAL.OpenConnection(ref con);
//            SqlCommand com = con.CreateCommand();
//            com.CommandText = updateCommandText;
//            AddParameters(com);

//            com.ExecuteNonQuery();
//            com.Dispose();
//            ConnectionDAL.CloseConnection(ref con);
//        }

//        #endregion

//        #region Delete

//        #endregion

//        #region General
//        private void AssignReaderValues(SqlCommand com)
//        {
//            SqlDataReader rd = com.ExecuteReader();
//            if (rd.Read() && rd.HasRows)
//            {
//                this._REQUEST_ID = rd["REQUEST_ID"].To<int>();
//                this._BODY = rd["BODY"].To<string>();
//                this._RECEIVED_DATE = rd["RECEIVED_DATE"].To<DateTime>();
//                this._USER_NAME = rd["USER_NAME"].To<string>();
//                this._API_TYPE = rd["API_TYPE"].To<int>();
//                this._API_URI = rd["API_URI"].To<string>();
//                this._REQUEST_METHOD = rd["REQUEST_METHOD"].To<string>();
//            }
//            rd.Close();
//        }

//        private void AddParameters(SqlCommand com)
//        {
//            com.Parameters.AddWithValue("REQUEST_ID", this._REQUEST_ID.ValidateForDB());
//            com.Parameters.AddWithValue("BODY", this._BODY.ValidateForDB());
//            com.Parameters.AddWithValue("RECEIVED_DATE", this._RECEIVED_DATE.ValidateForDB());
//            com.Parameters.AddWithValue("USER_NAME", this._USER_NAME.ValidateForDB());
//            com.Parameters.AddWithValue("API_TYPE", this._API_TYPE.ValidateForDB());
//            com.Parameters.AddWithValue("API_URI", this._API_URI.ValidateForDB());
//            com.Parameters.AddWithValue("REQUEST_METHOD", this._REQUEST_METHOD.ValidateForDB());
//        }

//        #endregion
//    }
//}