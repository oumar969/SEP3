using Domain.Models;
using GraphQL.Types;

namespace Types;


public class UserType : ObjectGraphType<User>
{
    public UserType()
    {
        Field(x => x.UUID).Description("The unique identifier of the user.");
        Field(x => x.FirstName).Description("The first name of the user.");
        Field(x => x.LastName).Description("The last name of the user.");
        Field(x => x.Email).Description("The email address of the user.");
        // Password field is typically not exposed in GraphQL queries for security reasons.
        Field(x => x.IsLibrarian).Description("Indicates if the user is a librarian.");

    }
}