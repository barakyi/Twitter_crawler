using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Extensions;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Controllers;
using Tweetinvi.Core.Interfaces.DTO;
using Tweetinvi.Core.Interfaces.Models;
using Tweetinvi.Core.Interfaces.Models.Parameters;
using Tweetinvi.Core.Interfaces.oAuth;
using Tweetinvi.Core.Interfaces.Streaminvi;
using Tweetinvi.Json;
using Stream = Tweetinvi.Stream;
using System.Diagnostics;

namespace ConsoleApplication3
{
    class TweetObject
    {
        
        public long IdUser;
        public string NameUser;
        public int NumOfTweets;
        public int NumOfFollowers;
        public int NumOffolowing;  
     //   public Double AccountAge;
        public int LikesGivenToOthers;
    //    public long Retio;
        Stopwatch sss=new Stopwatch();
        
     public   int[, , , , , ,,] twtAnalytic = new int[0,0,0 ,0 ,0 ,0 ,0,0];
        

   

        public TweetObject(IUser user)
        {
            sss.Start();
            this.IdUser = user.Id;
            this.NameUser = user.ScreenName;
            this.NumOfFollowers = user.FollowersCount;
            this.NumOffolowing = user.FriendsCount;

            this.LikesGivenToOthers = user.FavouritesCount;
           
          
            this.NumOfTweets = user.StatusesCount;
           // this.AccountAge = (DateTime.Now - user.CreatedAt).TotalDays;
            //if (this.NumOffolowing!=0)
            //{
            //    this.Retio = (long)this.NumOfFollowers / (long)this.NumOffolowing;
            //}
            //else
            //{
            //    this.Retio =0;
            //}
        
            this.twtAnalytic = twttAnalytic(user,sss);
           
        }

        
        static int[, , , , , ,,] twttAnalytic(IUser user,Stopwatch sss)
        {
          
            // int NumOfMEDIA=0;
             int NumOfTxt=0;
             int NumOfUrl=0;
             int NumOfHashTag = 0;
             int NumOfUserMent = 0;
              int NumOfMyRT=0;
             int NumOfOthRT=0;
              int TweetPerDay=0;
              DateTime Startdate = DateTime.Now; ; DateTime EndDate=DateTime.Now;
              int numoftweetestimeline = 0;
              int likeGiven = 0;


              int i = 0; string[] lines = new string[400]; long simple = 0; ;
              var timelineParameter = Timeline.CreateUserTimelineRequestParameter(user); timelineParameter.MaximumNumberOfTweetsToRetrieve = 150;
              for (int k = 0; k < 1; k++)
              {



                  var timelineTweets = user.GetUserTimeline(timelineParameter);
               
                  if (timelineTweets != null)
                  {
                      foreach (var tltweet in timelineTweets)
                      {
                          if (i == 0)
                          {
                              Startdate = tltweet.CreatedAt.Date;
                          }

                          lines[i] = tltweet.Text;
                          i++;
                          simple = tltweet.Id;

                          if (tltweet.Urls.Count == 0 && tltweet.Media.IsNullOrEmpty() == true)
                          {
                              NumOfTxt++;//If the tweet does not have a link or a pic, then classified as a simple wording tweet

                          }
                          else
                          {
                              NumOfUrl += tltweet.Urls.Count();//if the tweet  have a url then count it


                              //if (tltweet.Media.IsNullOrEmpty() != true)
                              //{
                              //   // NumOfMEDIA += tltweet.Media.Count();//if the tweet  have a media then count it

                              //}


                          }



                          EndDate = tltweet.CreatedAt.Date;

                          if (tltweet.IsRetweet)
                          {
                              NumOfMyRT++;
                          }
                          else
                          {
                              NumOfOthRT += tltweet.RetweetCount;
                              NumOfUserMent += tltweet.Entities.UserMentions.Count;
                              NumOfHashTag += tltweet.Entities.Hashtags.Count;
                              numoftweetestimeline++;
                              likeGiven+= tltweet.FavouriteCount;
                          }


                          
                          


                      }


                      timelineParameter.MaxId = simple - 1;
                    
                      
                  }
              }
            TimeSpan span = Startdate - EndDate;
            if (span.Days==0)
            {
                TweetPerDay = 0;
            }
            else
            {
                TweetPerDay = numoftweetestimeline / span.Days;
            }
           

    

            int[, , , , , ,,] RES = new int[,,,,,,,] { { { {{{ { {{NumOfTxt, NumOfUrl, NumOfMyRT, NumOfOthRT, TweetPerDay,NumOfUserMent,NumOfHashTag,likeGiven} } }}} } } } };


            return RES;
        }

      
        
    }
}
