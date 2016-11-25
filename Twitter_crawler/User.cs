using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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


namespace ConsoleApplication3
{
    class User
    {
        static void Main(string[] args)
        {






            Stopwatch SS = new Stopwatch(); Stopwatch timeBtweenLoops = new Stopwatch();
            SS.Start(); timeBtweenLoops.Start();
            DataTable table = new DataTable();
            table.Columns.Add("Twitter ID", typeof(long));
            table.Columns.Add("Twitter ScreenName", typeof(string));
            table.Columns.Add("NumOfTweets", typeof(int));
            table.Columns.Add("NumOfFollowers", typeof(int));
            table.Columns.Add("NumOffolowing", typeof(int));
            //table.Columns.Add("AccountAge", typeof(int));
            table.Columns.Add("LikesGivenToOthers", typeof(int));
            //table.Columns.Add("Retio", typeof(long));
            table.Columns.Add("NumOfTxt", typeof(int));
            //table.Columns.Add("NumOfMEDIA", typeof(int));
            table.Columns.Add("NumOfUrl", typeof(int));
            table.Columns.Add("NumOfMyRT", typeof(int));
            table.Columns.Add("NumOfOthRT", typeof(int));
            table.Columns.Add("TweetPerDay", typeof(int));
            table.Columns.Add("NumOfUserMent", typeof(int));
            table.Columns.Add("NumOfHashTag", typeof(int));
            table.Columns.Add("LikesGivenToMe", typeof(int));
            int filenum = 0;
            

            Queue<long> QofTwitter = new Queue <long>();
            QofTwitter.Enqueue(1012130216);//justi
            int numTOext = 25; int numfr = 4000;
            int loopall = 0;
              var DEVuser1 = TwitterCredentials.CreateCredentials("TOken1", "Token2", "Token3", "Token4");
              var DEVuser2 = TwitterCredentials.CreateCredentials("TOken1", "Token2", "Token3", "Token4");
              var DEVuser3 = TwitterCredentials.CreateCredentials("TOken1", "Token2", "Token3", "Token4");
              var DEVuser4 = TwitterCredentials.CreateCredentials("TOken1", "Token2", "Token3", "Token4");
              var DEVuser5 = TwitterCredentials.CreateCredentials("TOken1", "Token2", "Token3", "Token4");
              var DEVuser6 = TwitterCredentials.CreateCredentials("TOken1", "Token2", "Token3", "Token4");

              while (SS.ElapsedMilliseconds<900000*4)
              {



                  TwitterCredentials.ExecuteOperationWithCredentials(DEVuser1, () =>
                    {

                        Console.WriteLine(SS.Elapsed.ToString() + "conct to twitter");
                        var user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());
                        user.FriendIds = user.GetFriendIds(numfr).ToList();

                        for (int i = 0; i < user.FriendIds.Count; i++)
                        {
                            QofTwitter.Enqueue(user.FriendIds[i]);
                        }







                        int loop = 1;

                        while (user != null)
                        {

                            if (loop % numTOext != 0)
                            {

                                TweetObject tweeter = new TweetObject(user);

                                table.Rows.Add(tweeter.IdUser, tweeter.NameUser, tweeter.NumOfTweets, tweeter.NumOfFollowers, tweeter.NumOffolowing,
                                tweeter.LikesGivenToOthers, tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0,0], tweeter.twtAnalytic[0,0, 0, 0, 0, 0, 0, 1],
                                tweeter.twtAnalytic[0,0, 0, 0, 0, 0, 0, 2], tweeter.twtAnalytic[0,0, 0, 0, 0, 0, 0, 3], tweeter.twtAnalytic[0,0, 0, 0, 0, 0, 0, 4],
                                tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 5], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 6], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 7]);

                                Console.WriteLine(table.Rows.Count);

                                user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());
                                loop++;

                            }
                            else
                            {
                                //    Console.WriteLine(loop);
                                //    Console.WriteLine(SS.Elapsed);

                                //    Thread.Sleep(900000-Convert.ToInt32( SS.ElapsedMilliseconds));
                                //    Console.WriteLine(SS.Elapsed);
                                //    SS.Restart();
                                //    user = Tweetinvi.User.GetUserFromId(ll[loop]);
                                //    loop++;

                                user = null;
                            }

                        }


                        });





                  TwitterCredentials.ExecuteOperationWithCredentials(DEVuser2, () =>
                  {

                      Console.WriteLine(SS.Elapsed.ToString() + "conct to twitter");
                      var user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());

                      //var yoyo=RateLimit.GetCredentialsRateLimits(BarakY);
                      //Console.WriteLine(yoyo.StatusesUserTimelineLimit.Remaining);
                      user.FriendIds = user.GetFriendIds(numfr).ToList();
                      //var yoyo=RateLimit.GetCredentialsRateLimits(BarakY);
                      //Console.WriteLine(yoyo.StatusesUserTimelineLimit.Remaining);
                      for (int i = 0; i < user.FriendIds.Count; i++)
                      {
                          QofTwitter.Enqueue(user.FriendIds[i]);
                      } 







                      int loop = 1;

                      while (user != null)
                      {

                          if (loop % numTOext != 0)
                          {

                              TweetObject tweeter = new TweetObject(user);
                              table.Rows.Add(tweeter.IdUser, tweeter.NameUser, tweeter.NumOfTweets, tweeter.NumOfFollowers, tweeter.NumOffolowing,
                                                            tweeter.LikesGivenToOthers, tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0,0], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 1],
                                                            tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 2], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 3], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0,4],
                                                            tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 5], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 6], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 7]);

                              Console.WriteLine(table.Rows.Count);

                              user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());
                              loop++;

                          }
                          else
                          {
                              //    Console.WriteLine(loop);
                              //    Console.WriteLine(SS.Elapsed);

                              //    Thread.Sleep(900000-Convert.ToInt32( SS.ElapsedMilliseconds));
                              //    Console.WriteLine(SS.Elapsed);
                              //    SS.Restart();
                              //    user = Tweetinvi.User.GetUserFromId(ll[loop]);
                              //    loop++;

                              user = null;
                          }
                      }
                  });


                  TwitterCredentials.ExecuteOperationWithCredentials(DEVuser2, () =>
                 {

                     Console.WriteLine(SS.Elapsed.ToString() + "conct to twitter");
                     var user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());

                     //var yoyo=RateLimit.GetCredentialsRateLimits(BarakY);
                     //Console.WriteLine(yoyo.StatusesUserTimelineLimit.Remaining);
                   







                     int loop = 1;

                     while (user != null)
                     {

                         if (loop % numTOext != 0)
                         {

                             TweetObject tweeter = new TweetObject(user);

                             table.Rows.Add(tweeter.IdUser, tweeter.NameUser, tweeter.NumOfTweets, tweeter.NumOfFollowers, tweeter.NumOffolowing,
                                                           tweeter.LikesGivenToOthers, tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 0], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 1],
                                                           tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 2], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 3], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 4],
                                                           tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 5], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 6], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 7]);

                             Console.WriteLine(table.Rows.Count);

                             user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());
                             loop++;

                         }
                         else
                         {
                             //    Console.WriteLine(loop);
                             //    Console.WriteLine(SS.Elapsed);

                             //    Thread.Sleep(900000-Convert.ToInt32( SS.ElapsedMilliseconds));
                             //    Console.WriteLine(SS.Elapsed);
                             //    SS.Restart();
                             //    user = Tweetinvi.User.GetUserFromId(ll[loop]);
                             //    loop++;

                             user = null;
                         }
                     }


                 });

                  TwitterCredentials.ExecuteOperationWithCredentials(DEVuser3, () =>
                  {

                      Console.WriteLine(SS.Elapsed.ToString() + "conct to twitter");
                      var user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());

                      //var yoyo=RateLimit.GetCredentialsRateLimits(BarakY);
                      //Console.WriteLine(yoyo.StatusesUserTimelineLimit.Remaining);








                      int loop = 1;

                      while (user != null)
                      {

                          if (loop % numTOext != 0)
                          {

                              TweetObject tweeter = new TweetObject(user);

                              table.Rows.Add(tweeter.IdUser, tweeter.NameUser, tweeter.NumOfTweets, tweeter.NumOfFollowers, tweeter.NumOffolowing,
                                                            tweeter.LikesGivenToOthers, tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 0], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 1],
                                                            tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 2], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 3], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 4],
                                                            tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 5], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 6], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 7]);

                              Console.WriteLine(table.Rows.Count);

                              user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());
                              loop++;

                          }
                          else
                          {
                              //    Console.WriteLine(loop);
                              //    Console.WriteLine(SS.Elapsed);

                              //    Thread.Sleep(900000-Convert.ToInt32( SS.ElapsedMilliseconds));
                              //    Console.WriteLine(SS.Elapsed);
                              //    SS.Restart();
                              //    user = Tweetinvi.User.GetUserFromId(ll[loop]);
                              //    loop++;

                              user = null;
                          }
                      }


                  });

                  TwitterCredentials.ExecuteOperationWithCredentials(DEVuser4, () =>
                  {

                      Console.WriteLine(SS.Elapsed.ToString() + "conct to twitter");
                      var user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());





                      int loop = 1;

                      while (user != null)
                      {

                          if (loop % numTOext != 0)
                          {

                              TweetObject tweeter = new TweetObject(user);

                              table.Rows.Add(tweeter.IdUser, tweeter.NameUser, tweeter.NumOfTweets, tweeter.NumOfFollowers, tweeter.NumOffolowing,
                                                                tweeter.LikesGivenToOthers, tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 0], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 1],
                                                                tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 2], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 3], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 4],
                                                                tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 5], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 6], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 7]);
                              Console.WriteLine(table.Rows.Count);

                              user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());
                              loop++;

                          }
                          else
                          {
                              //    Console.WriteLine(loop);
                              //    Console.WriteLine(SS.Elapsed);

                              //    Thread.Sleep(900000-Convert.ToInt32( SS.ElapsedMilliseconds));
                              //    Console.WriteLine(SS.Elapsed);
                              //    SS.Restart();
                              //    user = Tweetinvi.User.GetUserFromId(ll[loop]);
                              //    loop++;
                              user = null;
                          }

                      }




                  });

                  TwitterCredentials.ExecuteOperationWithCredentials(DEVuser5, () =>
                  {

                      Console.WriteLine(SS.Elapsed.ToString() + "conct to twitter");
                      var user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());





                      int loop = 1;

                      while (user != null)
                      {

                          if (loop % numTOext != 0)
                          {

                              TweetObject tweeter = new TweetObject(user);

                              table.Rows.Add(tweeter.IdUser, tweeter.NameUser, tweeter.NumOfTweets, tweeter.NumOfFollowers, tweeter.NumOffolowing,
                                                                tweeter.LikesGivenToOthers, tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 0], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 1],
                                                                tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 2], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 3], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 4],
                                                                tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 5], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 6], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 7]);
                              Console.WriteLine(table.Rows.Count);

                              user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());
                              loop++;

                          }
                          else
                          {
                              //    Console.WriteLine(loop);
                              //    Console.WriteLine(SS.Elapsed);

                              //    Thread.Sleep(900000-Convert.ToInt32( SS.ElapsedMilliseconds));
                              //    Console.WriteLine(SS.Elapsed);
                              //    SS.Restart();
                              //    user = Tweetinvi.User.GetUserFromId(ll[loop]);
                              //    loop++;
                              user = null;
                          }

                      }




                  });
                  TwitterCredentials.ExecuteOperationWithCredentials(DEVuser6, () =>
                  {

                      Console.WriteLine(SS.Elapsed.ToString() + "conct to twitter");
                      var user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());





                      int loop = 1;

                      while (user != null)
                      {

                          if (loop % numTOext != 0)
                          {

                              TweetObject tweeter = new TweetObject(user);

                              table.Rows.Add(tweeter.IdUser, tweeter.NameUser, tweeter.NumOfTweets, tweeter.NumOfFollowers, tweeter.NumOffolowing,
                                                                tweeter.LikesGivenToOthers, tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 0], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 1],
                                                                tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 2], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 3], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 4],
                                                                tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 5], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 6], tweeter.twtAnalytic[0, 0, 0, 0, 0, 0, 0, 7]);
                              Console.WriteLine(table.Rows.Count);

                              user = Tweetinvi.User.GetUserFromId(QofTwitter.Dequeue());
                              loop++;

                          }
                          else
                          {
                              //    Console.WriteLine(loop);
                              //    Console.WriteLine(SS.Elapsed);

                              //    Thread.Sleep(900000-Convert.ToInt32( SS.ElapsedMilliseconds));
                              //    Console.WriteLine(SS.Elapsed);
                              //    SS.Restart();
                              //    user = Tweetinvi.User.GetUserFromId(ll[loop]);
                              //    loop++;
                              user = null;
                          }

                      }




                  });

                  new EXPORTtoEXL(table, "D:\\MyDataTable" + filenum + ".csv");

               
                  loopall++; filenum++;
                  Console.WriteLine(loopall + "*******************************************************");


                  Console.WriteLine(timeBtweenLoops.Elapsed.ToString());
                  timeBtweenLoops.Reset();

              }








              new EXPORTtoEXL(table, "D:\\MyDataTable" + filenum + ".csv");
        }



    }

  


    
}
