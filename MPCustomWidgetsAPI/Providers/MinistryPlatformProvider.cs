using Microservices.Interfaces;
using Microservices.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Platform.Clients.Http;
using Platform.Clients.PowerService;
using System.Dynamic;
using System.Xml.Linq;

namespace Microservices.Providers
{
    public class MinistryPlatformProvider
    {
        #region Parameters
        private readonly IConfiguration _configuration;
        private IPowerService _api { get; set; }
        private readonly DomainConnectionModel _domain;

        #endregion

        #region Constructor

        public MinistryPlatformProvider(IConfiguration configuration, DomainConnectionModel domain)
        {
            _configuration = configuration;
            _domain = domain;

            if (_domain == null)
            {
                _domain = new DomainConnectionModel()
                {
                    APIUrl = _configuration.GetValue<string>("MinistryPlatform:API"),
                    OAuthClientId = _configuration.GetValue<string>("MinistryPlatform:ClientID"),
                    OAuthClientSecret = _configuration.GetValue<string>("MinistryPlatform:Secret"),                    
                };
            }
            
            _api = PowerServiceClientFactory.CreateAsync(new Uri(_domain.APIUrl), _domain.OAuthClientId, _domain.OAuthClientSecret).Result;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Gets MP Base API Url
        /// </summary>
        /// <returns></returns>
        public string GetDomain()
        {
            return _domain.APIUrl;
        }

        /// <summary>
        /// Returns Details on Table Schema
        /// </summary>
        /// <returns></returns>
        public async Task<TableInfoCollection> GetTableSchema()
        {
            return await _api.GetTablesAsync();
        }

        /// <summary>
        /// Returns Hostname of MP Domain
        /// </summary>
        /// <returns></returns>
        public string GetDomainHostname()
        {
            Uri domainUri = new Uri(_domain.APIUrl);
            return domainUri.Host;
        }

        /// <summary>
        /// Returns Domain Encryption Key
        /// </summary>
        /// <returns></returns>
        public string GetEncryptionKey()
        {
            return _domain.Encryption_Key;
        }

        /// <summary>
        /// Returns Files Endpoint for MinistryPlatform API
        /// </summary>
        /// <returns></returns>
        public string GetFilesEndpoint()
        {
            return $"{GetDomain()}/files";
        }

        /// <summary>
        /// Returns information about the Domain
        /// </summary>
        /// <returns></returns>
        public async Task<DomainInfo> GetDomainInfoAsync()
        {
            return await _api.GetDomainInfoAsync();
        }

        /// <summary>
        /// Proxy Call for GetRecords (Collection)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="select"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="top"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetRecordsAsync<T>(
            string table,
            string filter,
            string? select = null,
            string? orderBy = null,
            string? groupBy = null,
            string? having = null,
            int top = 1000,
            int skip = 0)
        {
            return await _api.GetRecordsAsync<T>(
                table: table,
                select: select,
                filter: filter,
                orderBy: orderBy,
                groupBy: groupBy,
                having: having,
                top: top,
                skip: skip,
                distinct: false,
                userId: null,
                globalFilterId: null,
                complexObject: false);
        }

        /// <summary>
        /// Proxy Call for GetRecord (Single)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="id"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public async Task<T> GetRecordAsync<T>(
            string table,
            int id,
            string? select = null)
        {
            return await _api.GetRecordAsync<T>(
                table: table,
                id: id,
                select: select,
                complexObject: false);
        }

        /// <summary>
        /// Proxy Call for ExecuteStoredProcedureAsync
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ResultSet> ExecuteStoredProcedureAsync(
            string procedure,
            Dictionary<string, object> parameters)
        {
            if (String.IsNullOrWhiteSpace(procedure))
            {
                throw new ArgumentNullException("procedure");
            }

            return await _api.ExecuteProcedureAsync(procedure, parameters);
        }

        /// <summary>
        /// Creates New Single Record
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="record"></param>
        /// <param name="select"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<T> CreateRecordAsync<T>(string table, T record, string? select = null, int? userId = null)
        {
            var list = new List<T>();
            list.Add(record);

            var results = await CreateRecordsAsync<T>(table: table, records: list, select: select, userId: userId);
            return results.First();
        }

        /// <summary>
        /// Create Multiple Records from a List of Objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="records"></param>
        /// <param name="select"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IEnumerable<T>> CreateRecordsAsync<T>(string table, IEnumerable<T> records, string? select = null, int? userId = null)
        {
            if (String.IsNullOrWhiteSpace(table))
            {
                throw new ArgumentNullException("table");
            }

            if (records == null || !records.Any())
            {
                throw new ArgumentNullException("records");
            }

            var recordSet = new RecordSet();
            foreach (var i in records)
            {
                recordSet.Add(DynamicToType<Record>(i));
            }

            return await _api.CreateRecordsAsync<T>(table: table, records: recordSet, select: select, userId: userId);
        }

        /// <summary>
        /// Send Messages To Email Addresses
        /// </summary>
        /// <param name="message"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<Communication> SendMessageAsync(MessageInfo message, IEnumerable<FileAttachment> files = null)
        {
            return await _api.CreateCommunicationAsync(message, files);
        }

        /// <summary>
        /// Update a Single Record
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="record"></param>
        /// <param name="select"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<T> UpdateRecordAsync<T>(string table, T record, string? select = null, int? userId = null)
        {
            var list = new List<T>();
            list.Add(record);

            var results = await UpdateRecordsAsync<T>(table: table, records: list, select: select, userId: userId);
            return results.First();
        }

        /// <summary>
        /// Update a list of records
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="records"></param>
        /// <param name="select"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> UpdateRecordsAsync<T>(string table, IEnumerable<T> records, string? select = null, int? userId = null)
        {
            var recordSet = new RecordSet();
            foreach (var i in records)
            {
                recordSet.Add(DynamicToType<Record>(i));
            }

            return await _api.UpdateRecordsAsync<T>(table: table, records: recordSet, select: select, userId: userId);
        }

        /// <summary>
        /// Sends Email Messages Based on Contact_ID Recipients / Senders
        /// </summary>
        /// <param name="communication"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<Communication> SendEmailContactBased(CommunicationInfo communication, IEnumerable<FileAttachment> files = null)
        {
            return await _api.CreateCommunicationAsync(communication, files);
        }

        /// <summary>
        /// Sends Email Messages based on Email Addresses
        /// </summary>
        /// <param name="communication"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<Communication> SendEmailMessageBased(MessageInfo communication, IEnumerable<FileAttachment> files = null)
        {
            return await _api.CreateCommunicationAsync(communication, files);
        }

        /// <summary>
        /// Sends Text / SMS Messages
        /// </summary>
        /// <param name="communication"></param>
        /// <returns></returns>
        public async Task<Communication> SendTextMessageBased(TextInfo communication)
        {
            return await _api.CreateCommunicationAsync(communication);
        }

        /// <summary>
        /// Creates Files Attached to Tables and Records
        /// </summary>
        /// <param name="table"></param>
        /// <param name="recordId"></param>
        /// <param name="fileNames"></param>
        /// <param name="isDefaultImage"></param>
        /// <param name="longestDimension"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<FileDescriptionCollection> CreateFilesAsync(string table, int recordId, IEnumerable<string> fileNames, bool isDefaultImage, int longestDimension = 0, int? userId = null)
        {
            return await _api.CreateFilesAsync(
                table: table,
                recordId: recordId,
                fileNames: fileNames,
                isDefaultImage: isDefaultImage,
                longestDimension: longestDimension,
                userId: userId);
        }

        #endregion

        #region private methods
        /// <summary>
        /// Method that converts a dyanmic object to the passed Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>T</returns>
        private T DynamicToType<T>(dynamic obj)
        {
            var tempObj = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(tempObj);
        }

        /// <summary>
        /// Method to Convert IEnumerable&lt;dynamic&gt; to IEnumerable&lt;T&gt;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>IEnumerable&lt;T&gt;</returns>
        private IEnumerable<T> DynamicListToType<T>(IEnumerable<dynamic> obj)
        {
            ICollection<T> objOut = new List<T>();

            foreach (var o in obj)
            {
                objOut.Add(DynamicToType<T>(o));
            }

            return objOut;
        }
        #endregion
    }   
}