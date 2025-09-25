// using System;
// using FluentValidation;

// namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

// public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
// {
//     private readonly List<string> validCategories = ["Italian", "Mexican", "Japanese", "Indian", "American"];

//     public CreateRestaurantCommandValidator()
//     {
//         RuleFor(dto => dto.Name).Length(3, 50);
//         RuleFor(dto => dto.Description).MaximumLength(200);
//         RuleFor(dto => dto.Category)    .Must(list => validCategories.Cast<string>().Contains(list))
//         .WithMessage("Invalid category. Please from the valid categories.");
//         RuleFor(dto => dto.HasDelivery).NotNull();
//         RuleFor(dto => dto.ContactNumber).NotEmpty();
//         RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Invalid email format");
//         RuleFor(dto => dto.Street).NotEmpty();
//         RuleFor(dto => dto.City).NotEmpty();
//         RuleFor(dto => dto.PostalCode).NotEmpty();

        
        
//     }
// }
