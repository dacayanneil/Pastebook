using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PastebookEFModel;

namespace PastebookBL
{
    public class MapperBL
    {
        public PB_USER UserEntityToDb(UserEntity inputUser)
        {
            var newUser = new PB_USER();

            newUser.ID = inputUser.ID;
            newUser.USER_NAME = inputUser.Username;
            newUser.PASSWORD = inputUser.Password;
            newUser.SALT = inputUser.Salt;
            newUser.FIRST_NAME = inputUser.FirstName;
            newUser.LAST_NAME = inputUser.LastName;
            newUser.BIRTHDAY = inputUser.BirthDay;
            newUser.COUNTRY_ID = inputUser.CountryID;
            newUser.MOBILE_NO = inputUser.MobileNo;
            newUser.GENDER = inputUser.Gender;
            newUser.PROFILE_PIC = inputUser.ProfilePic;
            newUser.DATE_CREATED = inputUser.CreatedDate;
            newUser.ABOUT_ME = inputUser.AboutMe;
            newUser.EMAIL_ADDRESS = inputUser.EmailAddress;

            return newUser;
        }

        public UserEntity UserDbToEntity(PB_USER outputUser)
        {
            var user = new UserEntity();

            user.ID = outputUser.ID;
            user.Username = outputUser.USER_NAME;
            user.Password = outputUser.PASSWORD;
            user.Salt = outputUser.SALT;
            user.FirstName = outputUser.FIRST_NAME;
            user.LastName = outputUser.LAST_NAME;
            user.BirthDay = outputUser.BIRTHDAY;
            user.CountryID = outputUser.COUNTRY_ID.GetValueOrDefault();
            user.MobileNo = outputUser.MOBILE_NO;
            user.Gender = outputUser.GENDER;
            user.ProfilePic = outputUser.PROFILE_PIC;
            user.CreatedDate = outputUser.DATE_CREATED;
            user.AboutMe = outputUser.ABOUT_ME;
            user.EmailAddress = outputUser.EMAIL_ADDRESS;

            return user;
        }

        public CountryEntity CountryDbToEntity(PB_REF_COUNTRY outputCountry)
        {
            var country = new CountryEntity();

            country.ID = outputCountry.ID;
            country.Country = outputCountry.COUNTRY;

            return country;
        }

        public PostEntity PostDbToEntity(PB_POST outputPost)
        {
            var post = new PostEntity();

            post.ID = outputPost.ID;
            post.CreatedDate = outputPost.CREATED_DATE;
            post.Content = outputPost.CONTENT;
            post.Profile_Owner_ID = outputPost.PROFILE_OWNER_ID;
            post.Poster_ID = outputPost.POSTER_ID;

            return post;
        }

        public PB_POST PostEntityToDb(PostEntity inputPost)
        {
            var post = new PB_POST();

            post.ID = inputPost.ID;
            post.CREATED_DATE = inputPost.CreatedDate;
            post.CONTENT = inputPost.Content;
            post.PROFILE_OWNER_ID = inputPost.Profile_Owner_ID;
            post.POSTER_ID = inputPost.Poster_ID;

            return post;
        }

        public PB_LIKE LikeEntityToDb(LikeEntity inputLike)
        {
            var like = new PB_LIKE();

            like.ID = inputLike.ID;
            like.POST_ID = inputLike.Post_ID;
            like.LIKED_BY = inputLike.Liked_By;

            return like;
        }

        public LikeEntity LikeDbToEntity(PB_LIKE outputLike)
        {
            var like = new LikeEntity();

            like.ID = outputLike.ID;
            like.Post_ID = outputLike.POST_ID;
            like.Liked_By = outputLike.LIKED_BY;

            return like;
        }

        public PB_COMMENT CommentEntityToDb(CommentEntity inputComment)
        {
            var comment = new PB_COMMENT();

            comment.ID = inputComment.ID;
            comment.POST_ID = inputComment.Poster_ID;
            comment.DATE_CREATED = inputComment.CreatedDate;
            comment.CONTENT = inputComment.Content;
            comment.POSTER_ID = inputComment.Poster_ID;

            return comment;
        }

        public CommentEntity CommentDbToEntity(PB_COMMENT outputComment)
        {
            var comment = new CommentEntity();

            comment.ID = outputComment.ID;
            comment.CreatedDate = outputComment.DATE_CREATED;
            comment.Content = outputComment.CONTENT;
            comment.Post_ID = outputComment.POST_ID;
            comment.Poster_ID = outputComment.POSTER_ID;

            return comment;
        }
    }
}
