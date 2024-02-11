using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data;

    public class DataAccess : IDataAccess
    {
        private readonly BookDbContext _dbContext;

        public DataAccess(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Author> CreateAuthor(Author author)
        {
                //this is to that the id in database won't be the same as the last
                int authorId = 1;
                if (_dbContext.Authors.Any())
                {
                    authorId = _dbContext.Authors.Max(a => a.Id);
                    authorId++;
                }

                author.Id = authorId;

                // adding a new student to database
                _dbContext.Authors.Add(author);
                _dbContext.SaveChanges();
                return Task.FromResult(author);
            }
        
// get all authors 
        public Task<List<Author>> GetAllAuthors()
        {
            var listOfAuthors = _dbContext.Authors.ToListAsync();
            return listOfAuthors;
        }
        }