﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using DatebaseCP.Models;
using Microsoft.Data.Sqlite;

namespace DatebaseCP.Utils
{
    internal class ADO
    {
        private readonly string _dbFileName = "data.db";

        #region Specialities

        public ObservableCollection<Speciality> GetAllSpecialities()
        {
            string sql = "SELECT * FROM Speciality";

            ObservableCollection<Speciality> result = new ObservableCollection<Speciality>();

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var name = reader["Name"].ToString();

                            result.Add(new Speciality(id, name));
                        }
                    }
                }
            }
            return result;
        }

        public Speciality GetSpeciality(int id)
        {
            Speciality result = new Speciality();

            string sql = @"SELECT * FROM Speciality WHERE id = @specialityId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter specialityParameter = new SqliteParameter("@specialityId", id);
                command.Parameters.Add(specialityParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var name = reader["Name"].ToString();
                            result.Id = id;
                            result.Name = name;
                        }
                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            return result;
        }

        public void InsertSpeciality(Speciality speciality)
        {
            string sql = @"INSERT INTO Speciality (Name) VALUES (@name); SELECT last_insert_rowid();";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter nameParameter = new SqliteParameter("@name", speciality.Name);
                command.Parameters.Add(nameParameter);

                var id = (long)command.ExecuteScalar();
                speciality.Id = (int)id;
            }
        }

        public void UpdateSpeciality(Speciality speciality)
        {
            string sql = @"UPDATE Speciality SET Name = @name WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", speciality.Id);
                command.Parameters.Add(idParameter);
                SqliteParameter nameParameter = new SqliteParameter("@name", speciality.Name);
                command.Parameters.Add(nameParameter);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteSpeciality(Speciality speciality)
        {
            string sql = @"DELETE FROM Speciality WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", speciality.Id);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }

        public int CountGroupsWithSpecialities(int specialityId)
        {
            int result;

            string sql = @"SELECT COUNT(*) FROM Groups WHERE Speciality_id = @specialityId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter specialityIdParameter = new SqliteParameter("@specialityId", specialityId);
                command.Parameters.Add(specialityIdParameter);

                result = (int)(long)command.ExecuteScalar();
            }

            return result;
        }

        #endregion

        #region FormOfEducation

        public ObservableCollection<FormOfEducation> GetAllFormOfEducation()
        {
            string sql = "SELECT * FROM FormOfEducation";

            ObservableCollection<FormOfEducation> result = new ObservableCollection<FormOfEducation>();

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var name = reader["Name"].ToString();

                            result.Add(new FormOfEducation(id, name));
                        }
                    }
                }
            }
            return result;
        }

        public FormOfEducation GetFormOfEducation(int id)
        {
            FormOfEducation result = new FormOfEducation();

            string sql = @"SELECT * FROM FormOfEducation WHERE id = @formOfEducationId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter formOfEducationIdParameter = new SqliteParameter("@formOfEducationId", id);
                command.Parameters.Add(formOfEducationIdParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var name = reader["Name"].ToString();
                            result.Id = id;
                            result.Name = name;
                        }
                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            return result;
        }

        public void InsertFormOfEducation(FormOfEducation formOfEducation)
        {
            string sql = @"INSERT INTO FormOfEducation (Name) VALUES (@name); SELECT last_insert_rowid();";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter nameParameter = new SqliteParameter("@name", formOfEducation.Name);
                command.Parameters.Add(nameParameter);

                var id = (long)command.ExecuteScalar();
                formOfEducation.Id = (int)id;
            }
        }

        public void UpdateFormOfEducation(FormOfEducation formOfEducation)
        {
            string sql = @"UPDATE FormOfEducation SET Name = @name WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", formOfEducation.Id);
                command.Parameters.Add(idParameter);
                SqliteParameter nameParameter = new SqliteParameter("@name", formOfEducation.Name);
                command.Parameters.Add(nameParameter);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteFormOfEducation(FormOfEducation formOfEducation)
        {
            string sql = @"DELETE FROM FormOfEducation WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", formOfEducation.Id);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }

        public int CountGroupsWithFormOfEducation(int formOfEducationId)
        {
            int result;

            string sql = @"SELECT COUNT(*) FROM Groups WHERE FormOfEducation_id = @formOfEducationId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter formOfEducationIdParameter = new SqliteParameter("@formOfEducationId", formOfEducationId);
                command.Parameters.Add(formOfEducationIdParameter);

                result = (int)(long)command.ExecuteScalar();
            }

            return result;
        }

        #endregion

        #region Groups

        public ObservableCollection<Group> GetAllGroup()
        {
            ObservableCollection<Group> result = new ObservableCollection<Group>();

            string sql = @"SELECT * FROM Groups";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var name = reader["Name"].ToString();
                            var specialitiesId = int.Parse(reader["Speciality_id"].ToString());
                            var formOfEducationId = int.Parse(reader["FormOfEducation_id"].ToString());
                            var curatorId = int.Parse(reader["Curator_id"].ToString());

                            result.Add(new Group(id, name, specialitiesId, formOfEducationId, curatorId));
                        }
                    }
                }
            }

            return result;
        }

        public Group GetGroup(int id)
        {
            Group result = new Group();

            string sql = @"SELECT * FROM Groups WHERE id = @groupId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter groupIdParameter = new SqliteParameter("@groupId", id);
                command.Parameters.Add(groupIdParameter);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var name = reader["Name"].ToString();
                            var specialitiesId = int.Parse(reader["Speciality_id"].ToString());
                            var formOfEducationId = int.Parse(reader["FormOfEducation_id"].ToString());
                            var curatorId = int.Parse(reader["Curator_id"].ToString());

                            result.Id = id;
                            result.Name = name;
                            result.SpecialityId = specialitiesId;
                            result.FormOfEducationId = formOfEducationId;
                            result.CuratorId = curatorId;
                        }
                    }
                }
            }

            return result;
        }

        public void InsertGroup(Group group)
        {
            string sql = @"INSERT INTO Groups (Name, Speciality_id, FormOfEducation_id, Curator_id) VALUES (@name, @speciality_id, @formOfEducation_id, @curator_id); SELECT last_insert_rowid();";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter nameParameter = new SqliteParameter("@name", group.Name);
                command.Parameters.Add(nameParameter);
                SqliteParameter specialityIdParameter = new SqliteParameter("@speciality_id", group.SpecialityId);
                command.Parameters.Add(specialityIdParameter);
                SqliteParameter formOfEducationIdParameter =
                    new SqliteParameter("@formOfEducation_id", group.FormOfEducationId);
                command.Parameters.Add(formOfEducationIdParameter);
                SqliteParameter curatorIdParameter = new SqliteParameter("@curator_id", group.CuratorId);
                command.Parameters.Add(curatorIdParameter);


                var id = (long)command.ExecuteScalar();
                group.Id = (int)id;
            }
        }

        public void UpdateGroup(Group group)
        {
            string sql = @"UPDATE Groups SET Name = @name, Speciality_id = @speciality_id, FormOfEducation_id = @formOfEducation_id, Curator_id = @curator_id WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", group.Id);
                command.Parameters.Add(idParameter);
                SqliteParameter nameParameter = new SqliteParameter("@name", group.Name);
                command.Parameters.Add(nameParameter);
                SqliteParameter specialityIdParameter = new SqliteParameter("@speciality_id", group.SpecialityId);
                command.Parameters.Add(specialityIdParameter);
                SqliteParameter formOfEducationIdParameter =
                    new SqliteParameter("@formOfEducation_id", group.FormOfEducationId);
                command.Parameters.Add(formOfEducationIdParameter);
                SqliteParameter curatorIdParameter = new SqliteParameter("@curator_id", group.CuratorId);
                command.Parameters.Add(curatorIdParameter);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteGroup(Group group)
        {
            string sql = @"DELETE FROM Groups WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", group.Id);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }

        public int CountStudentsInGroup(int id)
        {
            int result;

            string sql = @"SELECT COUNT(*) FROM Students WHERE Group_id = @groupId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter formOfEducationIdParameter = new SqliteParameter("@groupId", id);
                command.Parameters.Add(formOfEducationIdParameter);

                result = (int)(long)command.ExecuteScalar();
            }

            return result;
        }

        #endregion

        #region Students

        public ObservableCollection<Student> GetAllStudents()
        {

            ObservableCollection<Student> result = new ObservableCollection<Student>();

            string sql = @"SELECT * FROM Students";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var lastName = reader["LastName"].ToString();
                            var firstName = reader["FirstName"].ToString();
                            var middleName = reader["MiddleName"].ToString();
                            var birthDate = DateTime.Parse(reader["BirthDate"].ToString());
                            var groupId = int.Parse(reader["Group_id"].ToString());
                            var recordBook = reader["RecordBook"].ToString();

                            result.Add(new Student(id, lastName, firstName, middleName, birthDate, groupId, recordBook));
                        }
                    }
                }
            }

            return result;

        }

        public ObservableCollection<Student> GetStudentsInGroup(int groupId)
        {
            ObservableCollection<Student> result = new ObservableCollection<Student>();

            string sql = @"SELECT * FROM Students WHERE Group_id = @groupId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@groupId", groupId);
                command.Parameters.Add(idParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var lastName = reader["LastName"].ToString();
                            var firstName = reader["FirstName"].ToString();
                            var middleName = reader["MiddleName"].ToString();
                            var birthDate = DateTime.Parse(reader["BirthDate"].ToString());
                            groupId = int.Parse(reader["Group_id"].ToString());
                            var recordBook = reader["RecordBook"].ToString();


                            result.Add(new Student(id, lastName, firstName, middleName, birthDate, groupId, recordBook));
                        }
                    }
                }
            }

            return result;
        }

        public Student GetStudent(int id)
        {
            Student result = new Student();

            string sql = @"SELECT * FROM Students WHERE id = @studentId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@studentId", id);
                command.Parameters.Add(idParameter);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var lastName = reader["LastName"].ToString();
                            var firstName = reader["FirstName"].ToString();
                            var middleName = reader["MiddleName"].ToString();
                            var birthDate = DateTime.Parse(reader["BirthDate"].ToString());
                            var groupId = int.Parse(reader["Group_id"].ToString());
                            var recordBook = reader["RecordBook"].ToString();

                            result.Id = id;
                            result.LastName = lastName;
                            result.FirstName = firstName;
                            result.MiddleName = middleName;
                            result.BirthDate = birthDate;
                            result.GroupId = groupId;
                            result.RecordBook = recordBook;
                        }
                    }
                }
            }
            return result;
        }

        public void InsertStudent(Student student)
        {
            string sql =
                @"INSERT INTO Students (LastName, FirstName, MiddleName, BirthDate, Group_id, RecordBook) VALUES (@lastName, @firstName, @middleName, @birthDate, @groupId, @recordBook); SELECT last_insert_rowid();";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter lastNameParameter = new SqliteParameter("@lastName", student.LastName);
                command.Parameters.Add(lastNameParameter);
                SqliteParameter firstNameParameter = new SqliteParameter("@firstName", student.FirstName);
                command.Parameters.Add(firstNameParameter);
                SqliteParameter middleNameParameter = new SqliteParameter("@middleName", student.MiddleName);
                command.Parameters.Add(middleNameParameter);
                SqliteParameter birthDateParameter = new SqliteParameter("@birthDate", student.BirthDate);
                command.Parameters.Add(birthDateParameter);
                SqliteParameter groupIdParameter = new SqliteParameter("@groupId", student.GroupId);
                command.Parameters.Add(groupIdParameter);
                SqliteParameter recordBookParameter = new SqliteParameter("@recordBook", student.RecordBook);
                command.Parameters.Add(recordBookParameter);

                var id = (long)command.ExecuteScalar();
                student.Id = (int)id;
            }
        }

        public void UpdateStudent(Student student)
        {
            string sql =
                @"UPDATE Students SET LastName = @lastName, FirstName = @firstName, MiddleName = @middleName, BirthDate = @birthDate, Group_id = @groupId, RecordBook = @recordBook WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter idParameter = new SqliteParameter("@id", student.Id);
                command.Parameters.Add(idParameter);
                SqliteParameter lastNameParameter = new SqliteParameter("@lastName", student.LastName);
                command.Parameters.Add(lastNameParameter);
                SqliteParameter firstNameParameter = new SqliteParameter("@firstName", student.FirstName);
                command.Parameters.Add(firstNameParameter);
                SqliteParameter middleNameParameter = new SqliteParameter("@middleName", student.MiddleName);
                command.Parameters.Add(middleNameParameter);
                SqliteParameter birthDateParameter = new SqliteParameter("@birthDate", student.BirthDate);
                command.Parameters.Add(birthDateParameter);
                SqliteParameter groupIdParameter = new SqliteParameter("@groupId", student.GroupId);
                command.Parameters.Add(groupIdParameter);
                SqliteParameter recordBookParameter = new SqliteParameter("@recordBook", student.RecordBook);
                command.Parameters.Add(recordBookParameter);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(Student student)
        {
            string sql = @"DELETE FROM Students WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", student.Id);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }

        #endregion

        #region Post

        public ObservableCollection<Post> GetAllPosts()
        {
            ObservableCollection<Post> result = new ObservableCollection<Post>();

            string sql = @"SELECT * FROM Post";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var name = reader["Name"].ToString();

                            result.Add(new Post(id, name));
                        }
                    }
                }
            }

            return result;
        }

        public ObservableCollection<Post> GetAllPostsForTeacher(int teacherId)
        {
            ObservableCollection<Post> result = new ObservableCollection<Post>();

            string sql = @"SELECT p.* 
                            FROM Post p 
                            INNER JOIN TeacherPost tp 
                            ON p.id = tp.Post_id 
                            WHERE tp.Teacher_id = @teacherId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter teacherIdParameter = new SqliteParameter("@teacherId", teacherId);
                command.Parameters.Add(teacherIdParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var name = reader["Name"].ToString();

                            result.Add(new Post(id, name));
                        }
                    }
                }
            }

            return result;
        }

        public ObservableCollection<Post> GetAllPostsForTeacherEdit(int teacherId)
        {
            ObservableCollection<Post> result = GetAllPosts();

            var tmp = GetPostsForTeacher(teacherId);

            foreach (var p in result)
            {
                if (tmp.Any(t => t.PostId == p.Id)) p.IsSelected = true;
            }

            return result;
        }

        public Post GetPost(int id)
        {
            Post result = new Post();

            string sql = @"SELECT * FROM Post WHERE id = @postId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter postIdParameter = new SqliteParameter("@postId", id);
                command.Parameters.Add(postIdParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var name = reader["Name"].ToString();
                            result.Id = id;
                            result.Name = name;
                        }
                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            return result;
        }

        public void InsertPost(Post post)
        {
            string sql = @"INSERT INTO Post (Name) VALUES (@name); SELECT last_insert_rowid();";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter nameParameter = new SqliteParameter("@name", post.Name);
                command.Parameters.Add(nameParameter);

                var id = (long)command.ExecuteScalar();
                post.Id = (int)id;
            }
        }

        public void UpdatePost(Post post)
        {
            string sql = @"UPDATE Post SET Name = @name WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", post.Id);
                command.Parameters.Add(idParameter);
                SqliteParameter nameParameter = new SqliteParameter("@name", post.Name);
                command.Parameters.Add(nameParameter);
                command.ExecuteNonQuery();
            }
        }

        public void DeletePost(Post post)
        {
            string sql = @"DELETE FROM Post WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", post.Id);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }

        #endregion

        #region TeacherPost

        public ObservableCollection<TeacherPost> GetPostsForTeacher(int id)
        {
            ObservableCollection<TeacherPost> result = new ObservableCollection<TeacherPost>();

            string sql = @"SELECT * FROM TeacherPost WHERE Teacher_id = @teacherId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter teacherIdParameter = new SqliteParameter("@teacherId", id);
                command.Parameters.Add(teacherIdParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var postId = int.Parse(reader["Post_id"].ToString());
                            result.Add(new TeacherPost(id, postId));
                        }
                    }
                    else
                    {
                        result = null;
                    }
                }
            }

            return result;
        }

        public void DeletePostsWithTeacher(int teacherId)
        {
            string sql = @"DELETE FROM TeacherPost WHERE Teacher_id = @teacherId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@teacherId", teacherId);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }

        public int CountTeacherWithPost(int postId)
        {
            int result;

            string sql = @"SELECT COUNT(*) FROM TeacherPost WHERE Post_id = @postId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter postIdParameter = new SqliteParameter("@postId", postId);
                command.Parameters.Add(postIdParameter);

                result = (int)(long)command.ExecuteScalar();
            }

            return result;
        }

        public void InsertTeacherPosts(int teacherId, IEnumerable<Post> posts)
        {
            string sql = @"INSERT INTO TeacherPost (Teacher_id, Post_id) VALUES (@teacher_id, @post_id)";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();

                foreach (var p in posts)
                {
                    SqliteCommand command = new(sql, connection);
                    SqliteParameter teacher_id = new SqliteParameter("@teacher_id", teacherId);
                    command.Parameters.Add(teacher_id);
                    SqliteParameter post_id = new SqliteParameter("@post_id", p.Id);
                    command.Parameters.Add(post_id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertTeacherPost(TeacherPost teacherPost)
        {
            string sql = @"INSERT INTO TeacherPost (Teacher_id, Post_id) VALUES (@teacher_id, @post_id)";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();

                SqliteCommand command = new(sql, connection);
                SqliteParameter teacher_id = new SqliteParameter("@teacher_id", teacherPost.TeacherId);
                command.Parameters.Add(teacher_id);
                SqliteParameter post_id = new SqliteParameter("@post_id", teacherPost.PostId);
                command.Parameters.Add(post_id);

                command.ExecuteNonQuery();
            }
        }

        #endregion

        #region Degree

        public ObservableCollection<Degree> GetAllDegrees()
        {
            ObservableCollection<Degree> result = new ObservableCollection<Degree>();

            string sql = @"SELECT * FROM Degrees";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var name = reader["Name"].ToString();

                            result.Add(new Degree(id, name));
                        }
                    }
                }
            }

            return result;
        }

        public ObservableCollection<Degree> GetAllDegreesForTeacher(int teacherId)
        {
            ObservableCollection<Degree> result = new ObservableCollection<Degree>();

            string sql = @"SELECT d.* 
                            FROM Degrees d 
                            INNER JOIN TeacherDegree td
                            ON d.id = td.Degree_id 
                            WHERE td.Teacher_id = @teacherId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter teacherIdParameter = new SqliteParameter("@teacherId", teacherId);
                command.Parameters.Add(teacherIdParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var name = reader["Name"].ToString();

                            result.Add(new Degree(id, name));
                        }
                    }
                }
            }

            return result;
        }

        public ObservableCollection<Degree> GetAllDegreesForTeacherEdit(int teacherId)
        {
            ObservableCollection<Degree> result = GetAllDegrees();

            var tmp = GetDegreesForTeacher(teacherId);

            foreach (var d in result)
            {
                if (tmp.Any(t => t.DegreeId == d.Id)) d.IsSelected = true;
            }

            return result;
        }

        public Degree GetDegree(int id)
        {
            Degree result = new Degree();

            string sql = @"SELECT * FROM Degrees WHERE id = @degreeId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter degreeIdParameter = new SqliteParameter("@degreeId", id);
                command.Parameters.Add(degreeIdParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var name = reader["Name"].ToString();
                            result.Id = id;
                            result.Name = name;
                        }
                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            return result;
        }

        public void InsertDegree(Degree degree)
        {
            string sql = @"INSERT INTO Degrees (Name) VALUES (@name); SELECT last_insert_rowid();";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter nameParameter = new SqliteParameter("@name", degree.Name);
                command.Parameters.Add(nameParameter);

                var id = (long)command.ExecuteScalar();
                degree.Id = (int)id;
            }
        }

        public void UpdateDegree(Degree degree)
        {
            string sql = @"UPDATE Degrees SET Name = @name WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", degree.Id);
                command.Parameters.Add(idParameter);
                SqliteParameter nameParameter = new SqliteParameter("@name", degree.Name);
                command.Parameters.Add(nameParameter);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteDegree(Degree degree)
        {
            string sql = @"DELETE FROM Post WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", degree.Id);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }
        
        #endregion

        #region TeacherDegree

        public ObservableCollection<TeacherDegree> GetDegreesForTeacher(int id)
        {
            ObservableCollection<TeacherDegree> result = new ObservableCollection<TeacherDegree>();

            string sql = @"SELECT * FROM TeacherDegree WHERE Teacher_id = @teacherId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter teacherIdParameter = new SqliteParameter("@teacherId", id);
                command.Parameters.Add(teacherIdParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var degreeId = int.Parse(reader["Degree_id"].ToString());
                            result.Add(new TeacherDegree(id, degreeId));
                        }
                    }
                    else
                    {
                        result = null;
                    }
                }
            }

            return result;
        }

        public void DeleteDegreesWithTeacher(int teacherId)
        {
            string sql = @"DELETE FROM TeacherDegree WHERE Teacher_id = @teacherId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@teacherId", teacherId);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }

        public int CountTeacherWithDegree(int degreeId)
        {
            int result;

            string sql = @"SELECT COUNT(*) FROM TeacherDegree WHERE Degree_id = @degreeId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter degreeIdParameter = new SqliteParameter("@degreeId", degreeId);
                command.Parameters.Add(degreeIdParameter);

                result = (int)(long)command.ExecuteScalar();
            }

            return result;
        }

        public void InsertTeacherDegrees(int teacherId, IEnumerable<Degree> degrees)
        {
            string sql = @"INSERT INTO TeacherDegree (Teacher_id, Degree_id) VALUES (@teacher_id, @degree_id)";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();

                foreach (var d in degrees)
                {
                    SqliteCommand command = new(sql, connection);
                    SqliteParameter teacher_id = new SqliteParameter("@teacher_id", teacherId);
                    command.Parameters.Add(teacher_id);
                    SqliteParameter degree_id = new SqliteParameter("@degree_id", d.Id);
                    command.Parameters.Add(degree_id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertTeacherDegree(TeacherDegree teacherDegree)
        {
            string sql = @"INSERT INTO TeacherDegree (Teacher_id, Degree_id) VALUES (@teacher_id, @degree_id)";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();

                SqliteCommand command = new(sql, connection);
                SqliteParameter teacher_id = new SqliteParameter("@teacher_id", teacherDegree.TeacherId);
                command.Parameters.Add(teacher_id);
                SqliteParameter degree_id = new SqliteParameter("@degree_id", teacherDegree.DegreeId);
                command.Parameters.Add(degree_id);

                command.ExecuteNonQuery();
            }
        }

        #endregion

        #region Title

        public ObservableCollection<TeacherTitle> GetAllTeacherTitle()
        {
            ObservableCollection<TeacherTitle> result = new ObservableCollection<TeacherTitle>();

            string sql = @"SELECT * FROM TeacherTitle";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var name = reader["Name"].ToString();

                            result.Add(new TeacherTitle(id, name));
                        }
                    }
                }
            }

            return result;
        }

        public TeacherTitle GetTeacherTitle(int id)
        {
            TeacherTitle result = new TeacherTitle();

            string sql = @"SELECT * FROM TeacherTitle WHERE id = @titleId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@titleId", id);
                command.Parameters.Add(idParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var name = reader["Name"].ToString();
                            result.Id = id;
                            result.Name = name;
                        }
                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            return result;
        }

        public void InsertTeacherTitle(TeacherTitle teacherTitle)
        {
            string sql = @"INSERT INTO TeacherTitle (Name) VALUES (@name); SELECT last_insert_rowid();";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter nameParameter = new SqliteParameter("@name", teacherTitle.Name);
                command.Parameters.Add(nameParameter);

                var id = (long)command.ExecuteScalar();
                teacherTitle.Id = (int)id;
            }
        }

        public void UpdateTeacherTitle(TeacherTitle teacherTitle)
        {
            string sql = @"UPDATE TeacherTitle SET Name = @name WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", teacherTitle.Id);
                command.Parameters.Add(idParameter);
                SqliteParameter nameParameter = new SqliteParameter("@name", teacherTitle.Name);
                command.Parameters.Add(nameParameter);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTeacherTitle(TeacherTitle teacherTitle)
        {
            string sql = @"DELETE FROM TeacherTitle WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", teacherTitle.Id);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }

        public int CountTeacherWithTitle(int titleId)
        {
            int result;

            string sql = @"SELECT COUNT(*) FROM Teachers WHERE TeachingTitle_id = @titleId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@titleId", titleId);
                command.Parameters.Add(idParameter);

                result = (int)(long)command.ExecuteScalar();
            }

            return result;
        }

        #endregion

        #region Teacher

        public DataTable GetAllTeachersTable()
        {
            string sql = @"SELECT
                                t.id,
                                t.LastName,
                                t.FirstName,
                                t.MiddleName,
                                t.BirthDate,
                                tt.Name as 'Title',
                                group_concat(DISTINCT d.name) as 'Degree',
                                group_concat(DISTINCT p.name) as 'Post'
                            FROM Teachers t 
                            INNER JOIN TeacherTitle tt
                                ON t.TeachingTitle_id = tt.id                            
                            INNER JOIN (TeacherDegree td INNER JOIN Degrees d ON td.Degree_id=d.id)
                                ON t.id = td.Teacher_id
                            INNER JOIN (TeacherPost tp INNER JOIN Post p ON tp.Post_id=p.id) 
                                ON t.id = tp.Teacher_id
                            GROUP BY t.id";

            var myTable = new DataTable();
            myTable.Columns.Add("id", typeof(int));
            myTable.Columns.Add("LastName", typeof(string));
            myTable.Columns.Add("FirstName", typeof(string));
            myTable.Columns.Add("MiddleName", typeof(string));
            myTable.Columns.Add("BirthDate", typeof(DateTime));
            myTable.Columns.Add("Title", typeof(string));
            myTable.Columns.Add("Degree", typeof(string));
            myTable.Columns.Add("Post", typeof(string));

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            myTable.Rows.Add(
                                int.Parse(reader["id"].ToString()),
                                reader["LastName"].ToString(),
                                reader["FirstName"].ToString(),
                                reader["MiddleName"].ToString(),
                                DateTime.Parse(reader["BirthDate"].ToString()),
                                reader["Title"].ToString(),
                                reader["Degree"].ToString(),
                                reader["Post"].ToString()
                            );
                        }
                    }
                }
            }
            return myTable;
        }

        public ObservableCollection<Teacher> GetAllTeachers()
        {
            ObservableCollection<Teacher> result = new ObservableCollection<Teacher>();

            string sql = @"SELECT * FROM Teachers";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var lastName = reader["LastName"].ToString();
                            var firstName = reader["FirstName"].ToString();
                            var middleName = reader["MiddleName"].ToString();
                            var birthDate = DateTime.Parse(reader["BirthDate"].ToString());
                            var titleId = int.Parse(reader["TeachingTitle_id"].ToString());

                            result.Add(new Teacher(id, lastName, firstName, middleName, birthDate, titleId));
                        }
                    }
                }
            }

            return result;

        }

        public Teacher GetTeacher(int id)
        {
            Teacher result = new Teacher();

            string sql = @"SELECT * FROM Teachers WHERE id = @teacherId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@teacherId", id);
                command.Parameters.Add(idParameter);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var lastName = reader["LastName"].ToString();
                            var firstName = reader["FirstName"].ToString();
                            var middleName = reader["MiddleName"].ToString();
                            var birthDate = DateTime.Parse(reader["BirthDate"].ToString());
                            var titleId = int.Parse(reader["TeachingTitle_id"].ToString());

                            result.Id = id;
                            result.LastName = lastName;
                            result.FirstName = firstName;
                            result.MiddleName = middleName;
                            result.BirthDate = birthDate;
                            result.TitleId = titleId;
                            result.Posts = GetAllPostsForTeacher(id).ToList();
                            result.Degrees = GetAllDegreesForTeacher(id).ToList();
                            result.Lessons = GetAllLessonsForTeacher(id).ToList();
                        }
                    }
                }
            }
            return result;
        }

        public ObservableCollection<Teacher> GetTeacherForLesson(int lessonId)
        {
            ObservableCollection<Teacher> result = new ObservableCollection<Teacher>();

            string sql = @"SELECT t.* FROM Teachers t INNER JOIN TeacherLesson tl ON t.id = tl.Teacher_id WHERE tl.Lesson_id = @lessonId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter lessonIdParameter = new SqliteParameter("@lessonId", lessonId);
                command.Parameters.Add(lessonIdParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var lastName = reader["LastName"].ToString();
                            var firstName = reader["FirstName"].ToString();
                            var middleName = reader["MiddleName"].ToString();
                            var birthDate = DateTime.Parse(reader["BirthDate"].ToString());
                            var titleId = int.Parse(reader["TeachingTitle_id"].ToString());

                            result.Add(new Teacher(id, lastName, firstName, middleName, birthDate, titleId));
                        }
                    }
                    else
                    {
                        result = null;
                    }
                }
            }

            return result;
        }

        public void InsertTeacher(Teacher teacher)
        {
            string sql =
                @"INSERT INTO Teachers (LastName, FirstName, MiddleName, BirthDate, TeachingTitle_id) VALUES (@lastName, @firstName, @middleName, @birthDate, @teachingTitleId); SELECT last_insert_rowid();";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter lastNameParameter = new SqliteParameter("@lastName", teacher.LastName);
                command.Parameters.Add(lastNameParameter);
                SqliteParameter firstNameParameter = new SqliteParameter("@firstName", teacher.FirstName);
                command.Parameters.Add(firstNameParameter);
                SqliteParameter middleNameParameter = new SqliteParameter("@middleName", teacher.MiddleName);
                command.Parameters.Add(middleNameParameter);
                SqliteParameter birthDateParameter = new SqliteParameter("@birthDate", teacher.BirthDate);
                command.Parameters.Add(birthDateParameter);
                SqliteParameter teachingTitleId = new SqliteParameter("@teachingTitleId", teacher.TitleId);
                command.Parameters.Add(teachingTitleId);

                var id = (long)command.ExecuteScalar();
                teacher.Id = (int)id;
            }
        }

        public void UpdateTeacher(Teacher teacher)
        {
            string sql =
                @"UPDATE Teachers SET LastName = @lastName, FirstName = @firstName, MiddleName = @middleName, BirthDate = @birthDate, TeachingTitle_id = @teachingTitleId WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter idParameter = new SqliteParameter("@id", teacher.Id);
                command.Parameters.Add(idParameter);
                SqliteParameter lastNameParameter = new SqliteParameter("@lastName", teacher.LastName);
                command.Parameters.Add(lastNameParameter);
                SqliteParameter firstNameParameter = new SqliteParameter("@firstName", teacher.FirstName);
                command.Parameters.Add(firstNameParameter);
                SqliteParameter middleNameParameter = new SqliteParameter("@middleName", teacher.MiddleName);
                command.Parameters.Add(middleNameParameter);
                SqliteParameter birthDateParameter = new SqliteParameter("@birthDate", teacher.BirthDate);
                command.Parameters.Add(birthDateParameter);
                SqliteParameter teachingTitleId = new SqliteParameter("@teachingTitleId", teacher.TitleId);
                command.Parameters.Add(teachingTitleId);

                command.ExecuteNonQuery();
            }

        }

        public void DeleteTeacher(Teacher teacher)
        {
            string sql = @"DELETE FROM Teachers WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", teacher.Id);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }

        #endregion

        #region Lesson

        public ObservableCollection<Lesson> GetAllLessons()
        {
            string sql = "SELECT * FROM Lessons";

            ObservableCollection<Lesson> result = new ObservableCollection<Lesson>();

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var name = reader["Name"].ToString();

                            result.Add(new Lesson(id, name));
                        }
                    }
                }
            }
            return result;
        }

        public ObservableCollection<Lesson> GetAllLessonsForTeacher(int teacherId)
        {
            ObservableCollection<Lesson> result = new ObservableCollection<Lesson>();

            string sql = @"SELECT l.* 
                            FROM Lessons l
                            INNER JOIN TeacherLesson tl
                            ON l.id = tl.Lesson_id  
                            WHERE tl.Teacher_id = @teacherId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter teacherIdParameter = new SqliteParameter("@teacherId", teacherId);
                command.Parameters.Add(teacherIdParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var name = reader["Name"].ToString();

                            result.Add(new Lesson(id, name));
                        }
                    }
                }
            }

            return result;
        }

        public ObservableCollection<Lesson> GetAllLessonsForTeacherEdit(int teacherId)
        {
            ObservableCollection<Lesson> result = GetAllLessons();

            var tmp = GetLessonsForTeacher(teacherId);

            foreach (var l in result)
            {
                if (tmp.Any(t => t.LessonId == l.Id)) l.IsSelected = true;
            }

            return result;
        }
        
        public void InsertLesson(Lesson lesson)
        {
            string sql = @"INSERT INTO Lessons (Name) VALUES (@name); SELECT last_insert_rowid();";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter nameParameter = new SqliteParameter("@name", lesson.Name);
                command.Parameters.Add(nameParameter);

                var id = (long)command.ExecuteScalar();
                lesson.Id = (int)id;
            }
        }

        public void UpdateLesson(Lesson lesson)
        {
            string sql = @"UPDATE Lessons SET Name = @name WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", lesson.Id);
                command.Parameters.Add(idParameter);
                SqliteParameter nameParameter = new SqliteParameter("@name", lesson.Name);
                command.Parameters.Add(nameParameter);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteLesson(Lesson lesson)
        {
            string sql = @"DELETE FROM Lessons WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", lesson.Id);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }

        public int CountLesson(int id)
        {
            int result;

            string sql = @"SELECT COUNT(*) FROM Diary WHERE Lesson_id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", id);
                command.Parameters.Add(idParameter);

                result = (int)(long)command.ExecuteScalar();
            }

            return result;
        }

        #endregion

        #region TeacherLesson
        
        public void InsertTeacherLesson(TeacherLesson teacherLesson)
        {
            string sql = @"INSERT INTO TeacherLesson (Teacher_id, Lesson_id) VALUES (@teacher_id, @lesson_id)";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();

                SqliteCommand command = new(sql, connection);
                SqliteParameter teacher_id = new SqliteParameter("@teacher_id", teacherLesson.TeacherId);
                command.Parameters.Add(teacher_id);
                SqliteParameter lesson_id = new SqliteParameter("@lesson_id", teacherLesson.LessonId);
                command.Parameters.Add(lesson_id);

                command.ExecuteNonQuery();
            }
        }

        public void InsertTeacherLessons(int teacherId, IEnumerable<Lesson> lessons)
        {
            string sql = @"INSERT INTO TeacherLesson (Teacher_id, Lesson_id) VALUES (@teacher_id, @lesson_id)";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();

                foreach (var l in lessons)
                {
                    SqliteCommand command = new(sql, connection);
                    SqliteParameter teacher_id = new SqliteParameter("@teacher_id", teacherId);
                    command.Parameters.Add(teacher_id);
                    SqliteParameter lesson_id = new SqliteParameter("@lesson_id", l.Id);
                    command.Parameters.Add(lesson_id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public ObservableCollection<TeacherLesson> GetLessonsForTeacher(int id)
        {
            ObservableCollection<TeacherLesson> result = new ObservableCollection<TeacherLesson>();

            string sql = @"SELECT * FROM TeacherLesson WHERE Teacher_id = @teacherId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter teacherIdParameter = new SqliteParameter("@teacherId", id);
                command.Parameters.Add(teacherIdParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var lessonId = int.Parse(reader["Lesson_id"].ToString());
                            result.Add(new TeacherLesson(id, lessonId));
                        }
                    }
                    else
                    {
                        result = null;
                    }
                }
            }

            return result;
        }

        public void DeleteLessonsWithTeacher(int teacherId)
        {
            string sql = @"DELETE FROM TeacherLesson WHERE Teacher_id = @teacherId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@teacherId", teacherId);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }

        #endregion

        #region TypesCertification

        public ObservableCollection<TypeCertification> GetAllTypeCertifications()
        {
            string sql = "SELECT * FROM TypesCertification";

            ObservableCollection<TypeCertification> result = new ObservableCollection<TypeCertification>();

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = int.Parse(reader["id"].ToString());
                            var name = reader["Name"].ToString();

                            result.Add(new TypeCertification(id, name));
                        }
                    }
                }
            }
            return result;
        }

        public void InsertTypeCertification(TypeCertification typeCertification)
        {
            string sql = @"INSERT INTO TypesCertification (Name) VALUES (@name); SELECT last_insert_rowid();";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter nameParameter = new SqliteParameter("@name", typeCertification.Name);
                command.Parameters.Add(nameParameter);

                var id = (long)command.ExecuteScalar();
                typeCertification.Id = (int)id;
            }
        }

        public void UpdateTypeCertification(TypeCertification typeCertification)
        {
            string sql = @"UPDATE TypesCertification SET Name = @name WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", typeCertification.Id);
                command.Parameters.Add(idParameter);
                SqliteParameter nameParameter = new SqliteParameter("@name", typeCertification.Name);
                command.Parameters.Add(nameParameter);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTypeCertification(TypeCertification typeCertification)
        {
            string sql = @"DELETE FROM TypesCertification WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", typeCertification.Id);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }

        public int CountTypeCertification(int id)
        {
            int result;

            string sql = @"SELECT COUNT(*) FROM Diary WHERE Type_id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", id);
                command.Parameters.Add(idParameter);

                result = (int)(long)command.ExecuteScalar();
            }

            return result;
        }

        #endregion

        #region Diary

        public DataTable GetAllDiaresForStudent(int id)
        {
            string sql = @"SELECT
                                d.id,
                                d.Date,
                                l.Name as Lesson,
                                tc.Name as Type,
                                d.Score,
                                t.id as TeacherId,
                                t.LastName || ' ' || t.FirstName AS Teacher
                        FROM Diary d 
                        INNER JOIN Lessons l
                            ON d.Lesson_id = l.id
                        INNER JOIN TypesCertification tc
                            ON d.Type_id = tc.id
                        INNER JOIN Teachers t
                            ON d.Teacher_id = t.id
                        WHERE d.Student_id = @studentId";

            var myTable = new DataTable();
            myTable.Columns.Add("id", typeof(int));
            myTable.Columns.Add("Date", typeof(DateTime));
            myTable.Columns.Add("Lesson", typeof(string));
            myTable.Columns.Add("Type", typeof(string));
            myTable.Columns.Add("Score", typeof(int));
            myTable.Columns.Add("TeacherId", typeof(int));
            myTable.Columns.Add("TeacherName", typeof(string));

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@studentId", id);
                command.Parameters.Add(idParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            myTable.Rows.Add(
                                int.Parse(reader["id"].ToString()),
                                DateTime.Parse(reader["Date"].ToString()),
                                reader["Lesson"].ToString(),
                                reader["Type"].ToString(),
                                int.Parse(reader["Score"].ToString()),
                                int.Parse(reader["TeacherId"].ToString()),
                                reader["Teacher"].ToString()
                            );
                        }
                    }
                }
            }
            return myTable;
        }

        public DataTable GetAllDiaresForTeacher(int id)
        {
            string sql = @"SELECT
                                d.id,
                                d.Date,
                                l.Name as Lesson,
                                tc.Name as Type,
                                d.Score,
                                s.LastName || ' ' || s.FirstName AS Student
                        FROM Diary d 
                        INNER JOIN Lessons l
                            ON d.Lesson_id = l.id
                        INNER JOIN TypesCertification tc
                            ON d.Type_id = tc.id
                        INNER JOIN Students s
                            ON d.Student_id = s.id
                        WHERE d.Teacher_id = @teacherId";

            var myTable = new DataTable();
            myTable.Columns.Add("id", typeof(int));
            myTable.Columns.Add("Date", typeof(DateTime));
            myTable.Columns.Add("Lesson", typeof(string));
            myTable.Columns.Add("Type", typeof(string));
            myTable.Columns.Add("Score", typeof(int));
            myTable.Columns.Add("Student", typeof(string));

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@teacherId", id);
                command.Parameters.Add(idParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            myTable.Rows.Add(
                                int.Parse(reader["id"].ToString()),
                                DateTime.Parse(reader["Date"].ToString()),
                                reader["Lesson"].ToString(),
                                reader["Type"].ToString(),
                                int.Parse(reader["Score"].ToString()),
                                reader["Student"].ToString()
                            );
                        }
                    }
                }
            }
            return myTable;
        }

        public Diary GetDiary(int id)
        {
            Diary result = new Diary();

            string sql = @"SELECT * FROM Diary WHERE id = @diaryId";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@diaryId", id);
                command.Parameters.Add(idParameter);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var studentId = int.Parse(reader["Student_id"].ToString());
                            var teacherId = int.Parse(reader["Teacher_id"].ToString());
                            var date = DateTime.Parse(reader["Date"].ToString());
                            var score = int.Parse(reader["Score"].ToString());
                            var lessonId = int.Parse(reader["Lesson_id"].ToString());
                            var typeId = int.Parse(reader["Type_id"].ToString());

                            result.Id = id;
                            result.StudentId = studentId;
                            result.TeacherId = teacherId;
                            result.Date = date;
                            result.Score = score;
                            result.LessonId = lessonId;
                            result.TypeId = typeId;
                        }
                    }

                }
            }

            return result;
        }

        public void InsertDiary(Diary diary)
        {
            string sql =
                @"INSERT INTO Diary (Student_id, Teacher_id, Date, Score, Lesson_id, Type_id) VALUES (@studentId, @teacherId, @date, @score, @lessonId, @typeId); SELECT last_insert_rowid();";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter studentIdParameter = new SqliteParameter("@studentId", diary.StudentId);
                command.Parameters.Add(studentIdParameter);
                SqliteParameter teacherIdParameter = new SqliteParameter("@teacherId", diary.TeacherId);
                command.Parameters.Add(teacherIdParameter);
                SqliteParameter dateParameter = new SqliteParameter("@date", diary.Date);
                command.Parameters.Add(dateParameter);
                SqliteParameter scoreParameter = new SqliteParameter("@score", diary.Score);
                command.Parameters.Add(scoreParameter);
                SqliteParameter lessonIdId = new SqliteParameter("@lessonId", diary.LessonId);
                command.Parameters.Add(lessonIdId);
                SqliteParameter typeIdId = new SqliteParameter("@typeId", diary.TypeId);
                command.Parameters.Add(typeIdId);

                var id = (long)command.ExecuteScalar();
                diary.Id = (int)id;
            }
        }

        public void UpdateDiary(Diary diary)
        {
            string sql =
                @"UPDATE Diary SET Student_id = @studentId, Teacher_id = @teacherId, Date = @date, Score = @score, Lesson_id = @lessonId, Type_id = @typeId WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);

                SqliteParameter idParameter = new SqliteParameter("@id", diary.Id);
                command.Parameters.Add(idParameter);
                SqliteParameter studentIdParameter = new SqliteParameter("@studentId", diary.StudentId);
                command.Parameters.Add(studentIdParameter);
                SqliteParameter teacherIdParameter = new SqliteParameter("@teacherId", diary.TeacherId);
                command.Parameters.Add(teacherIdParameter);
                SqliteParameter dateParameter = new SqliteParameter("@date", diary.Date);
                command.Parameters.Add(dateParameter);
                SqliteParameter scoreParameter = new SqliteParameter("@score", diary.Score);
                command.Parameters.Add(scoreParameter);
                SqliteParameter lessonIdId = new SqliteParameter("@lessonId", diary.LessonId);
                command.Parameters.Add(lessonIdId);
                SqliteParameter typeIdId = new SqliteParameter("@typeId", diary.TypeId);
                command.Parameters.Add(typeIdId);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteDiary(Diary diary)
        {
            string sql = @"DELETE FROM Diary WHERE id = @id";

            using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
            {
                connection.Open();
                SqliteCommand command = new(sql, connection);
                SqliteParameter idParameter = new SqliteParameter("@id", diary.Id);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
        }

        public double ScoreStudent(int id)
        {
            double result = 0;

            string sql = @"SELECT avg(Score) FROM Diary WHERE Student_id = @id";

            try
            {
                using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
                {
                    connection.Open();
                    SqliteCommand command = new(sql, connection);
                    SqliteParameter idParameter = new SqliteParameter("@id", id);
                    command.Parameters.Add(idParameter);

                    result = (double)command.ExecuteScalar();
                }
            }
            catch
            {
            }

            return result;
        }

        public double ScoreGroup(int id)
        {
            double result = 0;

            string sql = @"SELECT avg(d.Score) FROM Diary d INNER JOIN Students s ON d.Student_id = s.Id WHERE s.Group_id = @id";

            try
            {
                using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
                {
                    connection.Open();
                    SqliteCommand command = new(sql, connection);
                    SqliteParameter idParameter = new SqliteParameter("@id", id);
                    command.Parameters.Add(idParameter);

                    result = (double)command.ExecuteScalar();
                }
            }
            catch
            {
            }

            return result;
        }

        public double ScoreTeacher(int id)
        {
            double result = 0;

            string sql = @"SELECT avg(Score) FROM Diary WHERE Teacher_id = @id";

            try
            {
                using (var connection = new SqliteConnection($"Data source={_dbFileName}"))
                {
                    connection.Open();
                    SqliteCommand command = new(sql, connection);
                    SqliteParameter idParameter = new SqliteParameter("@id", id);
                    command.Parameters.Add(idParameter);

                    result = (double)command.ExecuteScalar();
                }
            }
            catch
            {
            }

            return result;
        }

        #endregion
    }
}
