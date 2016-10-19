using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PastebookBL;

namespace Pastebook
{
    public class Mapper
    {
        public UserEntity UserModelToEntity(UserModel inputUser)
        {
            var user = new UserEntity();

            user.ID = inputUser.ID;
            user.Username = inputUser.Username;
            user.Password = inputUser.Password;
            user.Salt = inputUser.Salt;
            user.FirstName = inputUser.FirstName;
            user.LastName = inputUser.LastName;
            user.BirthDay = inputUser.BirthDay;
            user.CountryID = inputUser.CountryID;
            user.MobileNo = inputUser.MobileNo;
            user.Gender = inputUser.Gender;
            user.ProfilePic = inputUser.ProfilePic;
            user.CreatedDate = inputUser.DateCreated;
            user.AboutMe = inputUser.AboutMe;
            user.EmailAddress = inputUser.EmailAddress;

            return user;
        }

        public UserModel UserEntityToModel(UserEntity inputUser)
        {
            var user = new UserModel();

            user.ID = inputUser.ID;
            user.Username = inputUser.Username;
            user.Password = inputUser.Password;
            user.Salt = inputUser.Salt;
            user.FirstName = inputUser.FirstName;
            user.LastName = inputUser.LastName;
            user.BirthDay = inputUser.BirthDay;
            user.CountryID = inputUser.CountryID;
            user.MobileNo = inputUser.MobileNo;
            user.Gender = inputUser.Gender;
            user.ProfilePic = inputUser.ProfilePic;
            user.DateCreated = inputUser.CreatedDate;
            user.AboutMe = inputUser.AboutMe;
            user.EmailAddress = inputUser.EmailAddress;

            return user;
        }

        public CountryModel CountryEntityToModel(CountryEntity outputCountry)
        {
            var country = new CountryModel();
            country.ID = outputCountry.ID;
            country.Country = outputCountry.Country;
            return country;
        }

        public PostModel PostEntityToModel(PostEntity outputPost)
        {
            var post = new PostModel();

            post.ID = outputPost.ID;
            post.CreatedDate = outputPost.CreatedDate;
            post.Content = outputPost.Content;
            post.Profile_Owner_ID = outputPost.Profile_Owner_ID;
            post.Poster_ID = outputPost.Poster_ID;

            return post;
        }

        public PostEntity PostModelToEntity(PostModel inputPost)
        {
            var post = new PostEntity();

            post.ID = inputPost.ID;
            post.CreatedDate = inputPost.CreatedDate;
            post.Content = inputPost.Content;
            post.Profile_Owner_ID = inputPost.Profile_Owner_ID;
            post.Poster_ID = inputPost.Poster_ID;

            return post;
        }

        public LikeModel LikeEntityToModel(LikeEntity outputLike)
        {
            var like = new LikeModel();

            like.ID = outputLike.ID;
            like.Post_ID = outputLike.Post_ID;
            like.Liked_By = outputLike.Liked_By;

            return like;
        }

        public CommentModel CommentEntityToModel(CommentEntity outputComment)
        {
            var comment = new CommentModel();

            comment.ID = outputComment.ID;
            comment.CreatedDate = outputComment.CreatedDate;
            comment.Content = outputComment.Content;
            comment.Post_ID = outputComment.Post_ID;
            comment.Poster_ID = outputComment.Poster_ID;

            return comment;
        }
    }
}