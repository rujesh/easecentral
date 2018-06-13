# easecentral

Register
/api/account/register
POST Body
{
  "Email": "test@email.com",
  "Password": "Password@1",
  "ConfirmPassword": "Password@1"
}

Login
/api/Account/Login
POST Body
grant_type=password&username=test%40email.com&password=Password@1

Fetch json
/api/reddit
GET
Authorization: Bearer {access_token}

Save favorites
/api/reddit/favorites
POST Body
{
"reddit_id":"8qfw8l",
"permalink":"/r/announcements/comments/8qfw8l/protecting_the_free_and_open_internet_european/",
"url":"https://www.reddit.com/r/announcements/comments/8qfw8l/protecting_the_free_and_open_internet_european/",
"author":"arabscarab",
"tag":"www"
}

Get Favorites by tag
/api/reddit/favourites?tag=www
GET
Authorization: Bearer {access_token}
