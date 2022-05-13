using System;
using Azure;
using Azure.Data.Tables;
using MadWorld.Data.TableStorage.Context;
using MadWorld.Data.TableStorage.Context.Interfaces;
using MadWorld.Data.TableStorage.Info;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries
{
	public class ResumeQueries : IResumeQueries
	{
        private IResumeContext _context;

        public ResumeQueries(IResumeContext context)
        {
            _context = context;
        }

        public bool UpdateResume(Resume resume)
        {
            Response response = _context.AddEntity(resume);
            return response.IsError;
        }

        public Resume GetLast()
        {
            Pageable<Resume> resumes = _context.Query<Resume>(r => r.PartitionKey == PartitionKeys.Resume);
            return resumes.OrderByDescending(r => r.Timestamp).FirstOrDefault() ?? new Resume();
        }
    }
}

