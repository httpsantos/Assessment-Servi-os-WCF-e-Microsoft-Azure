﻿using Application.Models.Friends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Friend.Models.Output {
    public class OutputFriendModel {

        public OutputFriendModel() {
            this.Country = new OutputCountryModel();
            this.State = new OutputStateModel();
        }

        public static OutputFriendModel CreateOutputFriend(Friend friend) {
            return new OutputFriendModel() {
                Id = friend.Id,
                Name = friend.Name,
                LastName = friend.LastName,
                Email = friend.Email,
                BirthDate = friend.BirthDate.ToString(),
                Telephone = friend.Telephone
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string BirthDate { get; set; }

        public OutputCountryModel Country { get; set; }
        public OutputStateModel State { get; set; }
    }
}