﻿using API_Friend.Models.Input;
using API_Friend.Models.Output;
using Application.Repository.Territory.Countries;
using Application.Repository.Territory.Friends;
using Application.Repository.Territory.States;
using Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.UI.WebControls;

namespace API_Friend.Controllers {

    [RoutePrefix("api/friendship")]
    public class FriendshipController : ApiController {

        private IFriend GetFriendRepository { get; }

        public FriendshipController() {
            this.GetFriendRepository = Locator.GetInstanceOf<FriendRepository>();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Store(InputFriendshipModel input) {
            var Followed = await GetFriendRepository.Find(input.IdFollowed);
            var Follower = await GetFriendRepository.Find(input.IdFollower);

            if(Followed == null || Follower == null) {
                return BadRequest("Erro ao processar a solicitação");
            }

            Followed.Friends.Add(Follower);
            var user_updated = await GetFriendRepository.Update(Followed);

            if(user_updated != null) {
                var converted_friend = OutputFriendModel.CreateOutputFriend(user_updated);
                return Ok(converted_friend);
            }

            return BadRequest("Erro ao processar a solicitação");
        }
    }
}