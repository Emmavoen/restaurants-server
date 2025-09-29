// using System;
// using System.Collections.Generic;
// using System.Data;
// using System.Linq;
// using System.Threading.Tasks;

// namespace Restaurants.Application.Dishes.Command.CreateDish
// {
//     public class CreateDishCommandValidator : Abstractvalidator<CreateDishCommand>
//     {
//         public CreateDishCommandValidator()
//         {

//             RuleFor(v => v.Price)
//                 .GreaterThanOrEqualTo(0).WithMessage(" Price must be a non negative number");
                
//                 RuleFor(v => v.KiloCalories)
//                 .GreaterThanOrEqualTo(0).WithMessage(" KiloCalories must be a non negative number");

//         }
        
//     }
// }