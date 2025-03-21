﻿using CQRSExample.Data;
using CQRSExample.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSExample.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _dbContext;
        public StudentRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Student> AddStudentAsync(Student studentDetails)
        {
            var result = _dbContext.Students.Add(studentDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteStudentAsync(int Id)
        {
            var filteredData = _dbContext.Students.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Students.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int Id)
        {
            return await _dbContext.Students.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<int> UpdateStudentAsync(Student studentDetails)
        {
            _dbContext.Students.Update(studentDetails);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
