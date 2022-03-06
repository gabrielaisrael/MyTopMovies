using Microsoft.Extensions.Configuration;
using MyTopMovies.CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MyTopMovies.RepositoryLayer
{

    public class MoviesRepository : IMoviesRepository
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;
        public MoviesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration[key: "ConnectionStrings:DbSettingConnection"]);
        }
        public async Task<CreateMovieResponse> CreateMovie(CreateMovieRequest request)
        {
            CreateMovieResponse response = new CreateMovieResponse();
            response.IsSuccess = true;
            response.Message = "Successfull";
            try
            {
                string SqlQuery = "Insert Into Movie (Title, ImgUrl, CategoryId, Rate) values (@Title, @ImgUrl, @CategoryId, @Rate)";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 100;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Title", request.Title);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@ImgUrl", request.ImgUrl);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@CategoryId", request.CategoryId);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Rate", request.Rate);
                    _sqlConnection.Open();
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong";
                    }

                }

            } catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<ReadMovieResponse> ReadMovie()
        {
            ReadMovieResponse response = new ReadMovieResponse();
            response.IsSuccess = true;
            response.Message = "Successfull";
            try
            {
                string SqlQuery = "Select * FROM Movie order by Rate DESC;";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            response.readMovieData = new List<ReadMovieData>();
                            while (await sqlDataReader.ReadAsync())
                            {
                                ReadMovieData dbData = new ReadMovieData();
                                dbData.Title = sqlDataReader[name: "Title"] != DBNull.Value ? sqlDataReader[name: "Title"].ToString() : string.Empty;
                                dbData.ImgUrl = sqlDataReader[name: "ImgUrl"] != DBNull.Value ? sqlDataReader[name: "ImgUrl"].ToString() : string.Empty;
                                dbData.CategoryId = sqlDataReader[name: "CategoryId"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "CategoryId"]) : 0;
                                dbData.Rate = sqlDataReader[name: "Rate"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "Rate"]) : 0;
                                response.readMovieData.Add(dbData);
                            }
                        }
                    }
                }

            } catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }
        public async Task<ReadCategoryResponse> ReadCategory()
        {
            ReadCategoryResponse response = new ReadCategoryResponse();
            response.IsSuccess = true;
            response.Message = "Successfull";
            try
            {
                string SqlQuery = "Select * FROM Categories;";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            response.readCategoryData = new List<ReadCategoryData>();
                            while (await sqlDataReader.ReadAsync())
                            {
                                ReadCategoryData dbData = new ReadCategoryData();
                                dbData.Title = sqlDataReader[name: "Title"] != DBNull.Value ? sqlDataReader[name: "Title"].ToString() : string.Empty;
                                response.readCategoryData.Add(dbData);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<DeleteMovieResponse> DeleteMovie(DeleteMovieRequest request)
        {
            DeleteMovieResponse response = new DeleteMovieResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string SqlQuery = "DELETE FROM Movie WHERE Rate IN (SELECT MIN(Rate) FROM Movie);";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    //sqlCommand.Parameters.AddWithValue(parameterName: "@Id", request.Id);
                    _sqlConnection.Open();
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong";
                    }
                }
            } catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            } finally
            {
                _sqlConnection.Close();

            }
            return response;
        }

        public async Task<MovieCategoryResponse> MovieCategory()
        {
            MovieCategoryResponse response = new MovieCategoryResponse();
            response.IsSuccess = true;
            response.Message = "Successfull";
            try
            {
                //Get Movies of Category
                string SqlQuery = "SELECT Categories.Id, Movie.Title, Categories.Title FROM categories INNER JOIN Movie on Categories.Id = Movie.Id";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            response.MovieCategoryData = new List<MovieCategoryData>();
                            while (await sqlDataReader.ReadAsync())
                            {
                                MovieCategoryData dbData = new MovieCategoryData();
                                dbData.Title = sqlDataReader[name: "Title"] != DBNull.Value ? sqlDataReader[name: "Title"].ToString() : string.Empty;
                                response.MovieCategoryData.Add(dbData);
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<MovieIdResponse> MovieId(int Id)
        {
            MovieIdResponse response = new MovieIdResponse();
            response.IsSuccess = true;
            response.Message = "Successfull";
            try
            {
                //Get Movie by Id
                string SqlQuery = "SELECT Movie.Title, Movie.Rate FROM Movie WHERE Movie.Id=" + Id;
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            response.MovieIdData = new List<MovieIdData>();
                            while (await sqlDataReader.ReadAsync())
                            {
                                MovieIdData dbData = new MovieIdData();
                                dbData.Id = sqlDataReader[name: "Id"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "Id"]) : 0;
                                dbData.Title = sqlDataReader[name: "Title"] != DBNull.Value ? sqlDataReader[name: "Title"].ToString() : string.Empty;
                                dbData.ImgUrl = sqlDataReader[name: "ImgUrl"] != DBNull.Value ? sqlDataReader[name: "ImgUrl"].ToString() : string.Empty;
                                dbData.CategoryId = sqlDataReader[name: "CategoryId"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "CategoryId"]) : 0;
                                dbData.Rate = sqlDataReader[name: "Rate"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "Rate"]) : 0;
                                response.MovieIdData.Add(dbData);
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }
    }

}