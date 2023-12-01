using GraphQL.Types;

namespace Types;

public class UserInputType : InputObjectGraphType
{
    public UserInputType()
    {
        Name = "UserInput";
        Field<NonNullGraphType<StringGraphType>>("firstName");
        Field<NonNullGraphType<StringGraphType>>("lastName");
        Field<NonNullGraphType<StringGraphType>>("email");
        Field<NonNullGraphType<StringGraphType>>("password");
        Field<NonNullGraphType<BooleanGraphType>>("isLibrarian");
    }   
}