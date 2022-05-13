using System;
using System.Linq.Expressions;
using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Azure.Data.Tables.Sas;

namespace MadWorld.Data.TableStorage.Context.Interfaces
{
	public interface ITableContext
	{
		Response AddEntity<T>(T entity, CancellationToken cancellationToken = default) where T : ITableEntity;
		Task<Response> AddEntityAsync<T>(T entity, CancellationToken cancellationToken = default) where T : ITableEntity;
		Response<TableItem> Create(CancellationToken cancellationToken = default);
		Task<Response<TableItem>> CreateAsync(CancellationToken cancellationToken = default);
		Response<TableItem> CreateIfNotExists(CancellationToken cancellationToken = default);
		Task<Response<TableItem>> CreateIfNotExistsAsync(CancellationToken cancellationToken = default);
		Response Delete(CancellationToken cancellationToken = default);
		Task<Response> DeleteAsync(CancellationToken cancellationToken = default);
		Response DeleteEntity(string partitionKey, string rowKey, ETag ifMatch = default, CancellationToken cancellationToken = default);
        Task<Response> DeleteEntityAsync(string partitionKey, string rowKey, ETag ifMatch = default, CancellationToken cancellationToken = default);
		Uri GenerateSasUri(TableSasBuilder builder);
		Uri GenerateSasUri(TableSasPermissions permissions, DateTimeOffset expiresOn);
		Response<IReadOnlyList<TableSignedIdentifier>> GetAccessPolicies(CancellationToken cancellationToken = default);
		Task<Response<IReadOnlyList<TableSignedIdentifier>>> GetAccessPoliciesAsync(CancellationToken cancellationToken = default);
		Response<T> GetEntity<T>(string partitionKey, string rowKey, IEnumerable<string> select = default, CancellationToken cancellationToken = default) where T : class, ITableEntity, new();
		Task<Response<T>> GetEntityAsync<T>(string partitionKey, string rowKey, IEnumerable<string> select = default, CancellationToken cancellationToken = default) where T : class, ITableEntity, new();
		TableSasBuilder GetSasBuilder(TableSasPermissions permissions, DateTimeOffset expiresOn);
		TableSasBuilder GetSasBuilder(string rawPermissions, DateTimeOffset expiresOn);
		Pageable<T> Query<T>(Expression<Func<T, bool>> filter, int? maxPerPage = default, IEnumerable<string> select = default, CancellationToken cancellationToken = default) where T : class, ITableEntity, new();
		Pageable<T> Query<T>(string filter = default, int? maxPerPage = default, IEnumerable<string> select = default, CancellationToken cancellationToken = default) where T : class, ITableEntity, new();
		AsyncPageable<T> QueryAsync<T>(Expression<Func<T, bool>> filter, int? maxPerPage = default, IEnumerable<string> select = default, CancellationToken cancellationToken = default) where T : class, ITableEntity, new();
		AsyncPageable<T> QueryAsync<T>(string filter = default, int? maxPerPage = default, IEnumerable<string> select = default, CancellationToken cancellationToken = default) where T : class, ITableEntity, new();
		Response SetAccessPolicy(IEnumerable<TableSignedIdentifier> tableAcl, CancellationToken cancellationToken = default);
		Task<Response> SetAccessPolicyAsync(IEnumerable<TableSignedIdentifier> tableAcl, CancellationToken cancellationToken = default);
		Response<IReadOnlyList<Response>> SubmitTransaction(IEnumerable<TableTransactionAction> transactionActions, CancellationToken cancellationToken = default);
		Task<Response<IReadOnlyList<Response>>> SubmitTransactionAsync(IEnumerable<TableTransactionAction> transactionActions, CancellationToken cancellationToken = default);
		Response UpdateEntity<T>(T entity, ETag ifMatch, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default) where T : ITableEntity;
		Task<Response> UpdateEntityAsync<T>(T entity, ETag ifMatch, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default) where T : ITableEntity;
		Response UpsertEntity<T>(T entity, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default) where T : ITableEntity;
		Task<Response> UpsertEntityAsync<T>(T entity, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default) where T : ITableEntity;

		static string CreateQueryFilter(FormattableString filter)
        {
			return TableClient.CreateQueryFilter(filter);
        }

		static string CreateQueryFilter<T>(Expression<Func<T, bool>> filter)
        {
			return TableClient.CreateQueryFilter(filter);

		}
	}
}

