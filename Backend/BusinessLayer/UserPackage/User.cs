﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer.UserPackage
{
    class User : IPresistObject<DataAccessLayer.Objects.User>
    {
        private string email;
        private string password;
        private string nickname;
        private bool is_logged;
        private BoardPackage.Board myBoard;

        public User(string email, string password, string nickname)
        {
            this.email = email;
            this.password = password;
            this.nickname = nickname;
            this.is_logged = false;
            myBoard = new BoardPackage.Board(email);
        }
        public User(DataAccessLayer.Objects.User dalUser)
        {
            this.email = dalUser.email;
            this.password = dalUser.password;
            this.nickname = dalUser.nickname;
            this.myBoard = new BoardPackage.Board(dalUser.myBoard);

        }
        

        public string GetEmail()
        {
            return email;
        }

        public string GetPass()
        {
            return password;
        }

        public string GetNickname()
        {
            return nickname;
        }
        public BoardPackage.Board GetUserBoard()
        {
            return myBoard;
        }


        public bool Login(string pass)
        {
            if (this.password.Equals(pass))
            {
                is_logged = true;
                myBoard.SetIsULoggedIn(true);
                return true;
            }
            return false;
        }

        public void Logout()
        {
            if (!is_logged)
            {
                throw new Exception("You're already logged out");
            }
            is_logged = false;
            myBoard.SetIsULoggedIn(false);
        }

        public DataAccessLayer.Objects.User ToDalObject()
        {

            DataAccessLayer.Objects.User dalUser = new DataAccessLayer.Objects.User
                (this.email, this.password, this.nickname, this.myBoard.ToDalObject());
            return dalUser;
        }
    }
}
