### Assumptions

Based on observation, the field "nat" on the "result" model in JSON appears to be a country code, & has been treated as "nationality".
A logger will be used, but is an unknown type at this time. A simple temporary logger is included to capture log information.
Due to the random user API only returning a single item in the result set, that endpoint is called 10 times to create a better list.
The user model returned from the remote API does not contain an "Id" property. The users username has been used in place of that in regards to the instructions, as it should be unique.

### Items for improvement
A database (in-memory?) could be used in place of the singleton UserStorage class. This would more accurately replicate a production scenario and be more performant in that environment.
The User table in the database would then provide an "Id" for the viewmodel / DTO;
The "Favourite" status of the selected user is indicated by a field. A UX designer would probably have far better ideas on how to show this, and while a star was suggested in the brief I had some problems getting font-awesome working with Angular.
The "favouriteUsers" & "allUsers" could share a base class with only the user loading function being different. Likewise, all the other files could be shared. Unfortunately I am having issues setting the routing up and am trying to make it simple. Also, this breaks SOLID and if a requirement changes in future for one side more work will be required
.

### Choices
Rather than moving all front-end loading functionality into a seperate class or file, I have kept it within the component. This makes it available to the developer without too much hunting, and can be revisited if the amount of code increases.

### Used Libraries

The Nuget package F3R4L.DevPack.Api is my own & was developed as an easy-to-use API accessor. The source code can be found here https://github.com/F3R4L-DevPack/F3R4L.DevPack.Core.
