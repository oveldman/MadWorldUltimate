using System.Linq.Expressions;
using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Azure.Data.Tables.Sas;
using MadWorld.Data.TableStorage.Context.Interfaces;

namespace MadWorld.Data.TableStorage.Context
{
	public class TableContext : ITableContext
	{
		private readonly TableClient _table;

		public TableContext(TableServiceClient client, string name)
		{
            client.CreateTableIfNotExists(name);
			_table = client.GetTableClient(name);
		}

        public Response AddEntity<T>(T entity, CancellationToken cancellationToken = default) where T : ITableEntity
        {
            return _table.AddEntity(entity, cancellationToken);
        }

        public Task<Response> AddEntityAsync<T>(T entity, CancellationToken cancellationToken = default) where T : ITableEntity
        {
            return _table.AddEntityAsync(entity, cancellationToken);
        } 

        public Response<TableItem> Create(CancellationToken cancellationToken = default)
        {
            return _table.Create(cancellationToken);
        }

        public Task<Response<TableItem>> CreateAsync(CancellationToken cancellationToken = default)
        {
            return _table.CreateAsync(cancellationToken);
        }

        public Response<TableItem> CreateIfNotExists(CancellationToken cancellationToken = default)
        {
            return _table.CreateIfNotExists(cancellationToken);
        }

        public Task<Response<TableItem>> CreateIfNotExistsAsync(CancellationToken cancellationToken = default)
        {
            return _table.CreateIfNotExistsAsync(cancellationToken);
        }

        public Response Delete(CancellationToken cancellationToken = default)
        {
            return _table.Delete(cancellationToken);
        }

        public Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return _table.DeleteAsync(cancellationToken);
        }

        public Response DeleteEntity(string partitionKey, string rowKey, ETag ifMatch = default, CancellationToken cancellationToken = default)
        {
            return _table.DeleteEntity(partitionKey, rowKey, ifMatch, cancellationToken);
        }

        public Task<Response> DeleteEntityAsync(string partitionKey, string rowKey, ETag ifMatch = default, CancellationToken cancellationToken = default)
        {
            return _table.DeleteEntityAsync(partitionKey, rowKey, ifMatch, cancellationToken);
        }

        public Uri GenerateSasUri(TableSasBuilder builder)
        {
            return _table.GenerateSasUri(builder);
        }

        public Uri GenerateSasUri(TableSasPermissions permissions, DateTimeOffset expiresOn)
        {
            return _table.GenerateSasUri(permissions, expiresOn);
        }

        public Response<IReadOnlyList<TableSignedIdentifier>> GetAccessPolicies(CancellationToken cancellationToken = default)
        {
            return _table.GetAccessPolicies(cancellationToken);
        }

        public Task<Response<IReadOnlyList<TableSignedIdentifier>>> GetAccessPoliciesAsync(CancellationToken cancellationToken = default)
        {
            return _table.GetAccessPoliciesAsync(cancellationToken);
        }

        public TableSasBuilder GetSasBuilder(TableSasPermissions permissions, DateTimeOffset expiresOn)
        {
            return _table.GetSasBuilder(permissions, expiresOn);
        }

        public TableSasBuilder GetSasBuilder(string rawPermissions, DateTimeOffset expiresOn)
        {
            return _table.GetSasBuilder(rawPermissions, expiresOn);
        }

        public Response SetAccessPolicy(IEnumerable<TableSignedIdentifier> tableAcl, CancellationToken cancellationToken = default)
        {
            return _table.SetAccessPolicy(tableAcl, cancellationToken);
        }

        public Task<Response> SetAccessPolicyAsync(IEnumerable<TableSignedIdentifier> tableAcl, CancellationToken cancellationToken = default)
        {
            return _table.SetAccessPolicyAsync(tableAcl, cancellationToken);
        }

        public Response<IReadOnlyList<Response>> SubmitTransaction(IEnumerable<TableTransactionAction> transactionActions, CancellationToken cancellationToken = default)
        {
            return _table.SubmitTransaction(transactionActions, cancellationToken);
        }

        public Task<Response<IReadOnlyList<Response>>> SubmitTransactionAsync(IEnumerable<TableTransactionAction> transactionActions, CancellationToken cancellationToken = default)
        {
            return _table.SubmitTransactionAsync(transactionActions, cancellationToken);
        }

        public Response UpdateEntity<T>(T entity, ETag ifMatch, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default) where T : ITableEntity
        {
            return _table.UpdateEntity(entity, ifMatch, mode, cancellationToken);
        }

        public Task<Response> UpdateEntityAsync<T>(T entity, ETag ifMatch, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default) where T : ITableEntity
        {
            return _table.UpdateEntityAsync(entity, ifMatch, mode, cancellationToken);
        }

        public Response UpsertEntity<T>(T entity, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default) where T : ITableEntity
        {
            return _table.UpsertEntity(entity, mode, cancellationToken);
        }

        public Task<Response> UpsertEntityAsync<T>(T entity, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default) where T : ITableEntity
        {
            return _table.UpsertEntityAsync(entity, mode, cancellationToken);
        }

        Response<T> ITableContext.GetEntity<T>(string partitionKey, string rowKey, IEnumerable<string>? select, CancellationToken cancellationToken)
        {
            return _table.GetEntity<T>(partitionKey, rowKey, select, cancellationToken);
        }

        Task<Response<T>> ITableContext.GetEntityAsync<T>(string partitionKey, string rowKey, IEnumerable<string>? select, CancellationToken cancellationToken)
        {
            return _table.GetEntityAsync<T>(partitionKey, rowKey, select, cancellationToken);
        }

        Pageable<T> ITableContext.Query<T>(Expression<Func<T, bool>> filter, int? maxPerPage, IEnumerable<string>? select, CancellationToken cancellationToken)
        {
            return _table.Query(filter, maxPerPage, select, cancellationToken);
        }

        Pageable<T> ITableContext.Query<T>(string? filter, int? maxPerPage, IEnumerable<string>? select, CancellationToken cancellationToken)
        {
            return _table.Query<T>(filter, maxPerPage, select, cancellationToken);
        }

        AsyncPageable<T> ITableContext.QueryAsync<T>(Expression<Func<T, bool>> filter, int? maxPerPage, IEnumerable<string>? select, CancellationToken cancellationToken)
        {
            return _table.QueryAsync(filter, maxPerPage, select, cancellationToken);
        }

        AsyncPageable<T> ITableContext.QueryAsync<T>(string? filter, int? maxPerPage, IEnumerable<string>? select, CancellationToken cancellationToken)
        {
            return _table.QueryAsync<T>(filter, maxPerPage, select, cancellationToken);
        }
    }
}

