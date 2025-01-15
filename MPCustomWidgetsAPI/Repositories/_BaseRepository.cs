using Microservices.Interfaces;
using Microservices.Providers;
using MicroServices.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Platform.Clients.PowerService;

namespace Microservices.Repositories
{
    public class _BaseRepository
    {
        protected MinistryPlatformProvider mp;

        protected _BaseRepository(IDomainProvider domainProvider)
        {
            mp = domainProvider.GetMinistryPlatformProvider();
        }

        public async Task<DomainInfo> GetDomainInfoAsync()
        {
            return await mp.GetDomainInfoAsync();
        }

        public string GetDomain()
        {
            return mp.GetDomain();
        }

        public string GetDomainHostname()
        {
            return mp.GetDomainHostname();
        }


        /// <summary>
        /// Get Record By ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public async Task<T> GetRecord<T>(int id, string? select = null)
        {
            var tableName = GetTableName(typeof(T));

            return await mp.GetRecordAsync<T>(
                table: tableName,
                id: id,
                select: select);
        }

        /// <summary>
        /// Get Collection of Records
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <param name="select"></param>
        /// <param name="orderBy"></param>
        /// <param name="groupBy"></param>
        /// <param name="top"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetRecords<T>(string filter, string? select = null, string? orderBy = null, string? groupBy = null, int top = 1000, int skip = 0)
        {
            var tableName = GetTableName(typeof(T));

            return await mp.GetRecordsAsync<T>(
                table: tableName,
                filter: filter,
                orderBy: orderBy,
                select: select,
                groupBy: null,
                top: top,
                skip: skip);
        }

        /// <summary>
        /// Create record in dynamic entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="record"></param>
        /// <param name="select"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<T> CreateRecord<T>(T record, string? select = null, int? userId = null)
        {
            var tableName = GetTableName(typeof(T));

            return await mp.CreateRecordAsync<T>(
                table: tableName,
                record: record,
                select: select,
                userId: userId);
        }

        /// <summary>
        /// Update Collection of Records
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="records"></param>
        /// <param name="select"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> UpdateRecords<T>(IEnumerable<T> records, string? select = null, int? userId = null)
        {
            var tableName = GetTableName(typeof(T));

            return await mp.UpdateRecordsAsync<T>(
                table: tableName,
                records: records,
                select: select,
                userId: userId);
        }

        /// <summary>
        /// Update Record
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="record"></param>
        /// <param name="select"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<T> UpdateRecord<T>(T record, string? select = null, int? userId = null)
        {
            var tableName = GetTableName(typeof(T));

            return await mp.UpdateRecordAsync(
                table: tableName,
                record: record,
                select: select,
                userId: userId);
        }

        /// <summary>
        /// Gets the value of the MPTable Attribute on entity T
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private string? GetTableNameAttribute(System.Type t)
        {
            // Using reflection.
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);  // Reflection.

            foreach (System.Attribute attr in attrs)
            {
                if (attr is MPTable a)
                {
                    return a.GetName();
                }
            }

            return null;
        }

        /// <summary>
        /// Get Tablename for Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private string GetTableName(System.Type t)
        {
            var tableName = GetTableNameAttribute(t);

            if (tableName == null)
            {
                throw new ArgumentNullException("Model must contain MPTable attribute.");
            }

            return tableName;
        }
    }
}
