using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Data;

public interface IDataAccess {
    Task<Author> CreateAuthor(Author author);
}