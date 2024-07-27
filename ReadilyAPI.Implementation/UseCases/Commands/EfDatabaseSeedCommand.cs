using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands;
using ReadilyAPI.Application.UseCases.DTO.Roles;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands
{
    public class EfDatabaseSeedCommand : EfUseCase, IDatabaseSeedCommand
    {
        public EfDatabaseSeedCommand(ReadilyContext context) : base(context)
        {
        }

        public int Id => 67;

        public string Name => "Database Seed";

        public void Execute(bool data)
        {

            try
            {
                Context.Database.ExecuteSqlRaw("EXEC CleanDatabase");
            }
            catch
            {
                if
                    (
                    Context.Addresses.Any() || 
                    Context.Biographies.Any() || 
                    Context.Books.Any() || 
                    Context.BooksCategories.Any() || 
                    Context.BooksOrders.Any() || 
                    Context.Categories.Any() || 
                    Context.Comments.Any() || 
                    Context.CommentsImages.Any() || 
                    Context.DeliveryTypes.Any() || 
                    Context.ErrorLogs.Any() || 
                    Context.Images.Any() || 
                    Context.Messages.Any() || 
                    Context.Orders.Any() || 
                    Context.OrderStatuses.Any() || 
                    Context.Prices.Any() || 
                    Context.Publishers.Any() || 
                    Context.Reviews.Any() || 
                    Context.Roles.Any() || 
                    Context.RoleUseCases.Any() || 
                    Context.Users.Any() || 
                    Context.UsersCategories.Any() || 
                    Context.UserUseCases.Any() || 
                    Context.Wishlists.Any() ) 
                {
                    throw new ConflictException("Procedure CleanDatabase doesn't exists and database contains data.");
                }
            }

            #region Role Seed
            var roleAdmin = new Role
            {
                Name = "Admin"
            };

            var roleCustomer = new Role
            {
                Name = "Customer",
                RoleUseCases = new List<RoleUseCase>
                {
                    new RoleUseCase
                    {
                        UseCaseId = 6
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 17
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 23
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 29
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 36
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 37
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 38
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 43
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 49
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 50
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 51
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 52
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 53
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 54
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 55
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 56
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 57
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 58
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 61
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 62
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 63
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 64
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 65
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 66
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 67
                    }
                }
            };

            var roleWriter = new Role
            {
                Name = "Writer",
                RoleUseCases = new List<RoleUseCase>
                {
                    new RoleUseCase
                    {
                        UseCaseId = 6
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 17
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 23
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 29
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 36
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 37
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 38
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 43
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 45
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 46
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 47
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 48
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 49
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 50
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 51
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 52
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 53
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 54
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 55
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 56
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 57
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 58
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 61
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 62
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 63
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 64
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 65
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 66
                    },
                    new RoleUseCase
                    {
                        UseCaseId = 67
                    }
                }
            };

            Context.Roles.Add(roleAdmin);
            Context.Roles.Add(roleCustomer);
            Context.Roles.Add(roleWriter);
            #endregion

            #region Address Seed
            var address1 = new Address
            {
                AddressName = "Sunset Villa",
                AddressNumber = "123",
                City = "Los Angeles",
                State = "California",
                PostalCode = "90001",
                Country = "United States"
            };

            var address2 = new Address
            {
                AddressName = "Green Meadows",
                AddressNumber = "456",
                City = "New York City",
                State = "New York",
                PostalCode = "10001",
                Country = "United States"
            };

            var address3 = new Address
            {
                AddressName = "Ocean View Apartments",
                AddressNumber = "789",
                City = "Miami",
                State = "Florida",
                PostalCode = "33101",
                Country = "United States"
            };

            var address4 = new Address
            {
                AddressName = "Mountain Breeze Estate",
                AddressNumber = "101",
                City = "Denver",
                State = "Colorado",
                PostalCode = "80202",
                Country = "United States"
            };

            var address5 = new Address
            {
                AddressName = "Golden Gate Residences",
                AddressNumber = "246",
                City = "San Francisco",
                State = "California",
                PostalCode = "94102",
                Country = "United States"
            };

            var address6 = new Address
            {
                AddressName = "Emerald Heights",
                AddressNumber = "369",
                City = "Seattle",
                State = "Washington",
                PostalCode = "9801",
                Country = "United States"
            };

            var address7 = new Address
            {
                AddressName = "Maple Grove",
                AddressNumber = "555",
                City = "Toronto",
                State = "Ontario",
                PostalCode = "M5V 2X4",
                Country = "Canada"
            };

            var address8 = new Address
            {
                AddressName = "Riverfront Residences",
                AddressNumber = "777",
                City = "Vancouver",
                State = "British Columbia",
                PostalCode = "V6B 4Y8",
                Country = "Canada"
            };

            var address9 = new Address
            {
                AddressName = "Cherry Blossom Lane",
                AddressNumber = "888",
                City = "Tokyo",
                State = "Tokyo",
                PostalCode = "103-0011",
                Country = "Japan"
            };

            var address10 = new Address
            {
                AddressName = "Roppongi Hills",
                AddressNumber = "999",
                City = "Minato City",
                State = "Tokyo",
                PostalCode = "106-6108",
                Country = "Japan"
            };

            var address11 = new Address
            {
                AddressName = "Sydney Harbour View",
                AddressNumber = "111",
                City = "Sydney",
                State = "New South Wales",
                PostalCode = "2000",
                Country = "Australia"
            };

            var address12 = new Address
            {
                AddressName = "Melbourne Central",
                AddressNumber = "222",
                City = "Melbourne",
                State = "Victoria",
                PostalCode = "3000",
                Country = "Australia"
            };

            var address13 = new Address
            {
                AddressName = "Lion City Apartments",
                AddressNumber = "333",
                City = "Singapore",
                State = "Singapore",
                PostalCode = "238869",
                Country = "Singapore"
            };

            var address14 = new Address
            {
                AddressName = "Parisian Paradise",
                AddressNumber = "444",
                City = "Paris",
                State = "Paris",
                PostalCode = "75001",
                Country = "France"
            };

            var address15 = new Address
            {
                AddressName = "Rome Haven",
                AddressNumber = "555",
                City = "Rome",
                State = "Rome",
                PostalCode = "00184",
                Country = "Italy"
            };

            var address16 = new Address
            {
                AddressName = "Berlin Heights",
                AddressNumber = "666",
                City = "Berlin",
                State = "Berlin",
                PostalCode = "10178",
                Country = "Germany"
            };

            var address17 = new Address
            {
                AddressName = "London Bridge View",
                AddressNumber = "777",
                City = "London",
                State = "London",
                PostalCode = "SE1 9BG",
                Country = "United Kingdom"
            };

            var address18 = new Address
            {
                AddressName = "Amsterdam Canalside",
                AddressNumber = "888",
                City = "Amsterdam",
                State = "Amsterdam",
                PostalCode = "1012 JS",
                Country = "Netherlands"
            };

            var address19 = new Address
            {
                AddressName = "Dubai Marina Residences",
                AddressNumber = "999",
                City = "Dubai",
                State = "Dubai",
                PostalCode = "PO Box 93937",
                Country = "United Arab Emirates"
            };

            var address20 = new Address
            {
                AddressName = "Moscow Kremlin Views",
                AddressNumber = "123",
                City = "Moscow",
                State = "Moscow",
                PostalCode = "101000",
                Country = "Russia"
            };

            Context.Addresses.Add(address1);
            Context.Addresses.Add(address2);
            Context.Addresses.Add(address3);
            Context.Addresses.Add(address4);
            Context.Addresses.Add(address5);
            Context.Addresses.Add(address6);
            Context.Addresses.Add(address7);
            Context.Addresses.Add(address8);
            Context.Addresses.Add(address9);
            Context.Addresses.Add(address10);
            Context.Addresses.Add(address11);
            Context.Addresses.Add(address12);
            Context.Addresses.Add(address13);
            Context.Addresses.Add(address14);
            Context.Addresses.Add(address15);
            Context.Addresses.Add(address16);
            Context.Addresses.Add(address17);
            Context.Addresses.Add(address18);
            Context.Addresses.Add(address19);
            Context.Addresses.Add(address20);
            #endregion

            #region Category Seed
            var categoryParentMistery = new Category
            {
                Name = "Mystery",
                ParentId = null,
                Image = new Image
                {
                    Src = "c43ffb4a-4bbe-428b-baec-38e9e0810f18.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryParentMistery);

            var categoryChildrenDetectiveMistery = new Category
            {
                Name = "Detective Fiction",
                Parent = categoryParentMistery,
                Image = new Image
                {
                    Src = "f09f8335-fe60-4bc5-925a-72f0ddc1d815.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenDetectiveMistery);

            var categoryChildrenThrillersMistery = new Category
            {
                Name = "Thrillers",
                Parent = categoryParentMistery,
                Image = new Image
                {
                    Src = "e5ba608a-6f89-405c-a4b4-91723f4b741e.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenThrillersMistery);

            var categoryParentFiction = new Category
            {
                Name = "Fiction",
                ParentId = null,
                Image = new Image
                {
                    Src = "875e593a-575a-44cd-9f4f-6018f050fe2a.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryParentFiction);

            var categoryChildrenHorrorFiction = new Category
            {
                Name = "Horror Fiction",
                Parent = categoryParentFiction,
                Image = new Image
                {
                    Src = "4b4e87b4-e703-4fe8-b113-93c7b7b9f275.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenHorrorFiction);

            var categoryChildrenFantasyFiction = new Category
            {
                Name = "Fantasy Fiction",
                Parent = categoryParentFiction,
                Image = new Image
                {
                    Src = "facb7921-9a29-4b09-bb63-b6e8153d3ff3.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenFantasyFiction);

            var categoryParentBusiness = new Category
            {
                Name = "Business And Economics",
                ParentId = null,
                Image = new Image
                {
                    Src = "4291da11-7534-4e1d-ab23-44bbdb9205c0.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryParentBusiness);

            var categoryChildrenManagementBusiness = new Category
            {
                Name = "Management And Leadership",
                Parent = categoryParentBusiness,
                Image = new Image
                {
                    Src = "c8d50a8d-781b-4beb-ad74-6edcedc54fe9.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenManagementBusiness);

            var categoryChildrenFinanceBusiness = new Category
            {
                Name = "Finance And Accounting",
                Parent = categoryParentBusiness,
                Image = new Image
                {
                    Src = "a859ab96-f2de-4895-b0e1-e2a16695781d.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenFinanceBusiness);

            var categoryParentHistory = new Category
            {
                Name = "History",
                ParentId = null,
                Image = new Image
                {
                    Src = "db2c5f2f-f7d1-43a1-939d-0ffb3588bf76.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryParentHistory);

            var categoryChildrenCulturalHistory = new Category
            {
                Name = "Cultural History",
                Parent = categoryParentHistory,
                Image = new Image
                {
                    Src = "0d65035e-025f-47a2-b32c-6aa5fc1ab9ff.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenCulturalHistory);

            var categoryChildrenSocialHistory = new Category
            {
                Name = "Social History",
                Parent = categoryParentHistory,
                Image = new Image
                {
                    Src = "7ec4bb47-eba9-429a-8934-f2df4f870e69.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenSocialHistory);

            var categoryParentRomance = new Category
            {
                Name = "Romance",
                ParentId = null,
                Image = new Image
                {
                    Src = "9e43ea4c-d4c2-4c09-9296-ed3c29f7c47f.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryParentRomance);

            var categoryChildrenHistoricalRomance = new Category
            {
                Name = "Historical Romance",
                Parent = categoryParentRomance,
                Image = new Image
                {
                    Src = "251f74af-df18-4514-888d-b5daea99c515.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenHistoricalRomance);

            var categoryChildrenFantasyRomance = new Category
            {
                Name = "Fantasy Romance",
                Parent = categoryParentRomance,
                Image = new Image
                {
                    Src = "c130f597-d279-4a42-b3dd-7174f62630ab.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenFantasyRomance);

            var categoryParentChildren = new Category
            {
                Name = "Children\'s Books",
                ParentId = null,
                Image = new Image
                {
                    Src = "0ca4c202-ad15-40fc-ab6f-be5543caeeb9.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryParentChildren);

            var categoryChildrenFictionChildren = new Category
            {
                Name = "Young Adult Fiction",
                Parent = categoryParentChildren,
                Image = new Image
                {
                    Src = "74171e9b-473c-4e73-802d-08e6b6d73a6b.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenFictionChildren);

            var categoryChildrenStoriesChildren = new Category
            {
                Name = "Humorous Stories",
                Parent = categoryParentChildren,
                Image = new Image
                {
                    Src = "72fb395f-22e2-463f-8ff9-77c48e635242.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenStoriesChildren);

            var categoryParentTechnology = new Category
            {
                Name = "Technology And Science",
                ParentId = null,
                Image = new Image
                {
                    Src = "d0a06ab2-ddca-428d-9464-a8af79760756.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryParentTechnology);

            var categoryChildrenComputerTechnology = new Category
            {
                Name = "Computer Programming",
                Parent = categoryParentTechnology,
                Image = new Image
                {
                    Src = "87276948-93e6-4757-b3bc-4fdbdc9b5d28.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenComputerTechnology);

            var categoryChildrenCybersecurityTechnology = new Category
            {
                Name = "Cybersecurity And Hacking",
                Parent = categoryParentTechnology,
                Image = new Image
                {
                    Src = "9f9c5dd2-df99-4b8a-a4f1-2e1b0e308dab.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenCybersecurityTechnology);

            var categoryParentCooking = new Category
            {
                Name = "Cooking",
                ParentId = null,
                Image = new Image
                {
                    Src = "9419cb43-2d25-4e50-8990-d0b8c9483eba.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryParentCooking);

            var categoryChildrenHealthyCooking = new Category
            {
                Name = "Healthy Cooking",
                Parent = categoryParentCooking,
                Image = new Image
                {
                    Src = "974a5f37-e67f-4b70-ab9f-90e223cbdbf0.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenHealthyCooking);

            var categoryChildrenEthnicCooking = new Category
            {
                Name = "Ethnic Cuisines",
                Parent = categoryParentCooking,
                Image = new Image
                {
                    Src = "c1a4bdda-9218-4535-93ca-6d381be07a0e.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenEthnicCooking);

            var categoryParentImprovement = new Category
            {
                Name = "Self Improvement",
                ParentId = null,
                Image = new Image
                {
                    Src = "d1e54b33-78d2-486f-bf24-0ab12421529d.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryParentImprovement);

            var categoryChildrenPersonalImprovement = new Category
            {
                Name = "Personal Development",
                Parent = categoryParentImprovement,
                Image = new Image
                {
                    Src = "669d3908-0490-48d4-a08f-a3560fa7ff5f.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenPersonalImprovement);

            var categoryChildrenCommunicationImprovement = new Category
            {
                Name = "Communication Skills",
                Parent = categoryParentImprovement,
                Image = new Image
                {
                    Src = "bc9d4255-af49-44bc-b788-0c8c817d52b2.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenCommunicationImprovement);

            var categoryParentTravel = new Category
            {
                Name = "Travel",
                ParentId = null,
                Image = new Image
                {
                    Src = "5994d1f6-4efc-4265-bfe0-67b2b9541a46.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryParentTravel);

            var categoryChildrenCulturalTravel = new Category
            {
                Name = "Cultural Travel",
                Parent = categoryParentTravel,
                Image = new Image
                {
                    Src = "8a834f02-e2e4-44f3-a38f-2f9f588c9c84.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenCulturalTravel);

            var categoryChildrenAdventureTravel = new Category
            {
                Name = "Adventure Travel",
                Parent = categoryParentTravel,
                Image = new Image
                {
                    Src = "dd65a5fe-a577-4e9a-8a87-ba0a6874660e.jpg",
                    Alt = "Book Image"
                },
            };

            Context.Categories.Add(categoryChildrenAdventureTravel);
            #endregion

            #region Publisher Seed

            var publisherPottermore = new Publisher
            {
                Name = "Pottermore Publishing"
            };

            Context.Publishers.Add(publisherPottermore);

            var publisherScribner = new Publisher
            {
                Name = "Scribner"
            };

            Context.Publishers.Add(publisherScribner);

            var publisherWilliam = new Publisher
            {
                Name = "William Morrow Paperbacks"
            };

            Context.Publishers.Add(publisherWilliam);

            var publisherGrapevine = new Publisher
            {
                Name = "Grapevine"
            };

            Context.Publishers.Add(publisherGrapevine);

            var publisherMariner = new Publisher
            {
                Name = "Mariner Books"
            };
            
            Context.Publishers.Add(publisherMariner);

            var publisherSimon = new Publisher
            {
                Name = "Simon And Schuster"
            };

            Context.Publishers.Add(publisherSimon);

            var publisherKnopf = new Publisher
            {
                Name = "Knopf"
            };

            Context.Publishers.Add(publisherKnopf);

            var publisherFlatiron = new Publisher
            {
                Name = "Flatiron Books"
            };

            Context.Publishers.Add(publisherFlatiron);

            var publisherOreilly = new Publisher
            {
                Name = "Oreilly Media"
            };

            Context.Publishers.Add(publisherOreilly);

            var publisherYoungReaders = new Publisher
            {
                Name = "Random House Books For Young Readers"
            };

            Context.Publishers.Add(publisherYoungReaders);

            var publisherViking = new Publisher
            {
                Name = "Viking Books For Young Readers"
            };

            Context.Publishers.Add(publisherViking);

            var publisherHouse = new Publisher
            {
                Name = "Random House"
            };

            Context.Publishers.Add(publisherHouse);

            var publisherMartins = new Publisher
            {
                Name = "Martins Press"
            };

            Context.Publishers.Add(publisherMartins);

            var publisherLittle = new Publisher
            {
                Name = "Little Brown And Company"
            };

            Context.Publishers.Add(publisherLittle);

            var publisherNorton = new Publisher
            {
                Name = "Norton And Company"
            };

            Context.Add(publisherNorton);
            #endregion

            #region OrderStatus Seed
            var orderStatusPending = new OrderStatus
            {
                Name = "Pending"
            };

            Context.OrderStatuses.Add(orderStatusPending);

            var orderStatusProcessing = new OrderStatus
            {
                Name = "Processing"
            };

            Context.OrderStatuses.Add(orderStatusProcessing);

            var orderStatusShipped = new OrderStatus
            {
                Name = "Shipped"
            };

            Context.OrderStatuses.Add(orderStatusShipped);

            var orderStatusDelivered = new OrderStatus
            {
                Name = "Delivered"
            };

            Context.OrderStatuses.Add(orderStatusDelivered);
            #endregion

            #region DeliveryType Seed
            var deliveryStandard = new DeliveryType
            {
                Name = "Standard"
            };

            Context.DeliveryTypes.Add(deliveryStandard);

            var deliveryExpress = new DeliveryType
            {
                Name = "Express"
            };

            Context.DeliveryTypes.Add(deliveryExpress);

            var deliveryNextDay = new DeliveryType
            {
                Name = "Next Day"
            };

            Context.DeliveryTypes.Add(deliveryNextDay);

            var deliverySameDay = new DeliveryType
            {
                Name = "Same Day"
            };

            Context.DeliveryTypes.Add(deliverySameDay);
            #endregion

            #region User Seed

            var avatarDefault = new Image
            {
                Alt = "Avatar",
                Src = "defoult.jpg"
            };

            Context.Images.Add(avatarDefault);

            var userAdmin = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                Username = "Admin",
                Address = null,
                Role = roleAdmin,
                Email = "fake1@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = avatarDefault,
            };

            Context.Users.Add(userAdmin);

            var userCustomer = new User
            {
                FirstName = "Customer",
                LastName = "Customer",
                Username = "Customer",
                Address = null,
                Role = roleCustomer,
                Email = "fake2@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = avatarDefault,
            };

            Context.Users.Add(userCustomer);

            var userTest = new User
            {
                FirstName = "Test",
                LastName = "Test",
                Username = "Test123",
                Address = null,
                Role = roleCustomer,
                Email = "fake3@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = avatarDefault,
            };

            Context.Users.Add(userTest);

            var userStephen = new User
            {
                FirstName = "Stephen",
                LastName = "King",
                Username = "StephenKing",
                Address = address1,
                Role = roleWriter,
                Email = "fake4@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "b5fb50aa-b0c9-4cf3-a0bc-f885151ec204.jpg"
                },
                Biography = new Biography
                {
                    Text = "Stephen King is the author of more than fifty books, all of them worldwide bestsellers. His first crime thriller featuring Bill Hodges, MR MERCEDES, won the Edgar Award for best novel and was shortlisted for the CWA Gold Dagger Award. Both MR MERCEDES and END OF WATCH received the Goodreads Choice Award for the Best Mystery and Thriller of 2014 and 2016 respectively."
                }
            };

            Context.Users.Add(userStephen);

            var userTheodor = new User
            {
                FirstName = "Theodor",
                LastName = "Seuss",
                Username = "TheodorSeuss",
                Address = address2,
                Role = roleWriter,
                Email = "fake5@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "7cb96d0d-d206-4280-921c-eb6c5dd44b60.jpg"
                },
                Biography = new Biography
                {
                    Text = "Theodor Seuss Geisel—aka Dr. Seuss—is one of the most beloved children\'s book authors of all time. From The Cat in the Hat to Oh, the Places You\'ll Go!, his iconic characters, stories, and art style have been a lasting influence on generations of children and adults. The books he wrote and illustrated under the name Dr. Seuss (and others that he wrote but did not illustrate, including some under the pseudonyms Theo. LeSieg and Rosetta Stone) have been translated into 45 languages. Hundreds of millions of copies have found their way into homes and hearts around the world. Dr. Seuss\'s long list of awards includes Caldecott Honors, the Pulitzer Prize, and eight honorary doctorates. Works based on his original stories have won three Oscars, three Emmys, three Grammys, and a Peabody."
                }
            };

            Context.Users.Add(userTheodor);

            var userRoald = new User
            {
                FirstName = "Roald",
                LastName = "Dahl",
                Username = "RoaldDahl",
                Address = address3,
                Role = roleWriter,
                Email = "fake6@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "b00490c0-edf3-4089-8396-cd38520367e7.jpg"
                },
                Biography = new Biography 
                { 
                    Text = "The son of Norwegian parents, Roald Dahl was born in Wales in 1916 and educated at Repton. He was a fighter pilot for the RAF during World War Two, and it was while writing about his experiences during this time that he started his career as an author."
                }
            };

            Context.Users.Add(userRoald);

            var userNicholas = new User
            {
                FirstName = "Nicholas",
                LastName = "Sparks",
                Username = "NicholasSparks",
                Address = address4,
                Role = roleWriter,
                Email = "fake7@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "92d9bbb3-e72c-47a4-aacb-282e0d911c48.jpg"
                },
                Biography = new Biography 
                {
                    Text = "Nicholas Sparks is one of the world\'s most beloved storytellers. All of his books have been New York Times bestsellers, with over 105 million copies sold worldwide, in more than 50 languages, including over 75 million copies in the United States alone."
                }
            };

            Context.Users.Add(userNicholas);

            var userNora = new User
            {
                FirstName = "Nora",
                LastName = "Roberts",
                Username = "NoraRoberts",
                Address = address5,
                Role = roleWriter,
                Email = "fake8@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "f5fced39-4153-4b73-8777-3cc01c8aa023.jpg"
                },
                Biography = new Biography
                {
                    Text = "Nora Roberts is the #1 New York Times bestselling author of more than 200 novels, including Shelter in Place, Year One, Come Sundown, and many more. She is also the author of the bestselling In Death series written under the pen name J.D. Robb. There are more than five hundred million copies of her books in print."
                }
            };

            Context.Users.Add(userNora);

            var userDoris = new User
            {
                FirstName = "Doris Kearns Goodwin",
                LastName = "Goodwin",
                Username = "DorisGoodwin",
                Address = address6,
                Role = roleWriter,
                Email = "fake9@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "8a92d3e2-c651-44b4-8040-55804c7360ac.jpg"
                },
                Biography = new Biography
                {
                    Text = "Doris Kearns Goodwin\'s interest in leadership began more than half a century ago as a professor at Harvard. Her experiences working for LBJ in the White House and later assisting him on his memoirs led to her bestselling Lyndon Johnson and the American Dream. She followed up with the Pulitzer Prize-winning No Ordinary Time: Franklin & Eleanor Roosevelt: The Home Front in World War II. Goodwin earned the Lincoln Prize for the runaway bestseller Team of Rivals, the basis for Steven Spielberg\'s Academy Award-winning film Lincoln, and the Carnegie Medal for The Bully Pulpit, the New York Times bestselling chronicle of the friendship between Theodore Roosevelt and William Howard Taft. She lives in Concord, Massachusetts, with her husband, the writer Richard N. Goodwin. More at www.doriskearnsgoodwin.com @DorisKGoodwin"
                }
            };

            Context.Users.Add(userDoris);

            var userDavid = new User
            {
                FirstName = "David",
                LastName = "Cullough",
                Username = "DavidCullough",
                Address = address7,
                Role = roleWriter,
                Email = "fake10@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "7c3ef423-3b66-4174-9090-3c774fcca685.jpg"
                },
                Biography = new Biography
                {
                    Text = "David McCullough has twice received the Pulitzer Prize, for Truman and John Adams, and twice received the National Book Award, for The Path Between the Seas and Mornings on Horseback; His other widely praised books are 1776, Brave Companions, The Great Bridge, and The Johnstown Flood. He has been honored with the National Book Foundation Distinguished Contribution to American Letters Award, the National Humanities Medal, and the Presidential Medal of Freedom."
                }
            };

            Context.Users.Add(userDavid);

            var userJoanne = new User
            {
                FirstName = "Joanne",
                LastName = "Rowling",
                Username = "JoanneRowling",
                Address = address8,
                Role = roleWriter,
                Email = "fake11@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "31f72700-4180-4353-b337-52b7790c2f28.jpg"
                },
                Biography = new Biography
                {
                    Text = "J.K. Rowling is best-known as the author of the seven Harry Potter books, which were published between 1997 and 2007. The enduringly popular adventures of Harry, Ron and Hermione have gone on to sell over 600 million copies worldwide, be translated into 85 languages and made into eight blockbuster films."
                }
            };

            Context.Users.Add(userJoanne);

            var userWalter = new User
            {
                FirstName = "Walter",
                LastName = "Isaacson",
                Username = "WalterIsaacson",
                Address = address9,
                Role = roleWriter,
                Email = "fake12@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "1f580ca1-3bf8-4922-91ab-8b0e8e061937.jpg"
                },
                Biography = new Biography
                {
                    Text = "Walter Isaacson, University Professor of History at Tulane, has been CEO of the Aspen Institute, chairman of CNN, and editor of Time magazine. He is the author of Leonardo da Vinci; Steve Jobs; Einstein: His Life and Universe; Benjamin Franklin: An American Life; and Kissinger: A Biography. He is also the coauthor of The Wise Men: Six Friends and the World They Made."
                }
            };

            Context.Users.Add(userWalter);

            var userSteven = new User
            {
                FirstName = "Steven",
                LastName = "Levy",
                Username = "StevenLevy",
                Address = address10,
                Role = roleWriter,
                Email = "fake13@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "2a65715a-b3b6-4edb-aea1-be7a321d3ab5.jpg"
                },
                Biography = new Biography
                {
                    Text = "Levy is editor at large at Wired. Previous positions include editor in chief at Backchannel; and chief technology writer and a senior editor for Newsweek. In early 2020, his book \"Facebook: The Inside Story\" will appear, the product of over three years studying the company, which granted unprecedented access to its employees and executives. Levy has written previous seven books and has had articles published in Harper\\'s, Macworld, The New York Times Magazine, The New Yorker, Premiere, and Rolling Stone. Steven has won several awards during his 30+ years of writing about technology, including Hackers, which PC Magazine named the best Sci-Tech book written in the last twenty years and, Crypto, which won the grand eBook prize at the 2001 Frankfurt Book festival. \"In the Plex,\" the definitive book on Google, was named the Best Business Book of 2011 on both Amazon and Audible."
                }
            };

            Context.Users.Add(userSteven);

            var userJamie = new User
            {
                FirstName = "Jamie",
                LastName = "Oliver",
                Username = "JamieOliver",
                Address = address11,
                Role = roleWriter,
                Email = "fake14@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "11a97388-d379-47d2-83b4-1f747320a52b.jpg"
                },
                Biography = new Biography
                {
                    Text = "Jamie Oliver is a global phenomenon in food and campaigning. During a 20-year television and publishing career he has inspired millions of people to enjoy cooking from scratch and eating fresh, delicious food. Through his organization, Jamie is leading the charge on a global food revolution, aiming to reduce childhood obesity and improve everyone\'s health and happiness through food."
                }
            };

            Context.Users.Add(userJamie);

            var userJulia = new User
            {
                FirstName = "Julia",
                LastName = "Child",
                Username = "JuliaChild",
                Address = address12,
                Role = roleWriter,
                Email = "fake15@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "dfb0ee50-ca30-419d-8117-054ba4c3b533.jpg"
                },
                Biography = new Biography
                {
                    Text = "Julia Child was born in Pasadena, California. She was graduated from Smith College and worked for the OSS during World War II in Ceylon and China, where she met Paul Child. After they married they lived in Paris, where she studied at the Cordon Bleu and taught cooking with Simone Beck and Louisette Bertholle, with whom she wrote the first volume of Mastering the Art of French Cooking (1961). In 1963, Boston\'s WGBH launched The French Chef television series, which made her a national celebrity, earning her the Peabody Award in 1965 and an Emmy in 1966. Several public television shows and numerous cookbooks followed. She died in 2004."
                }
            };

            Context.Users.Add(userJulia);

            var userTony = new User
            {
                FirstName = "Tony",
                LastName = "Robbins",
                Username = "TonyRobbins",
                Address = address13,
                Role = roleWriter,
                Email = "fake16@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "dae17ab7-158c-4bb1-968c-aba807e63c79.jpg"
                },
                Biography = new Biography
                {
                    Text = "Tony Robbins is a bestselling author, entrepreneur, and philanthropist. For more than thirty-nine years, millions of people have enjoyed the warmth, humor, and the transformational power of Mr. Robbins\'s business and personal development events. He is the nation\'s #1 life and business strategist. He\'s called upon to consult and coach some of the world\'s finest athletes, entertainers, Fortune 500 CEOs, and even presidents of nations. Robbins is the chairman of a holding company comprised of more than a dozen businesses with combined sales exceeding five billion dollars a year. His philanthropic efforts helped provide more than 100 million meals in the last year alone. He lives in Palm Beach, Florida."
                }
            };

            Context.Users.Add(userTony);

            var userDale = new User
            {
                FirstName = "Dale",
                LastName = "Carnegie",
                Username = "DaleCarnegie",
                Address = address14,
                Role = roleWriter,
                Email = "fake17@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "98b63397-eec0-4862-9a68-9db896e8ca3c.jpg"
                },
                Biography = new Biography
                {
                    Text = "Dale Carnegie (1888-1955) described himself as a \"simple country boy\" from Missouri but was also a pioneer of the self-improvement genre. Since the 1936 publication of his first book, How to Win Friends and Influence People, he has touched millions of readers and his classic works continue to impact lives to this day."
                }
            };

            Context.Users.Add(userDale);

            var userPaul = new User
            {
                FirstName = "Paul",
                LastName = "Theroux",
                Username = "PaulTheroux",
                Address = address15,
                Role = roleWriter,
                Email = "fake18@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "f2b0840f-ba29-49b0-ace8-0259e7e0d34a.jpg"
                },
                Biography = new Biography
                {
                    Text = "Paul Theroux was born and educated in the United States. After graduating from university in 1963, he travelled first to Italy and then to Africa, where he worked as a Peace Corps teacher at a bush school in Malawi, and as a lecturer at Makerere University in Uganda. In 1968 he joined the University of Singapore and taught in the Department of English for three years. Throughout this time he was publishing short stories and journalism, and wrote a number of novels. Among these were Fong and the Indians, Girls at Play and Jungle Lovers, all of which appear in one volume, On the Edge of the Great Rift (Penguin, 1996)."
                }
            };

            Context.Users.Add(userPaul);

            var userBill = new User
            {
                FirstName = "Bill",
                LastName = "Bryson",
                Username = "BillBryson",
                Address = address16,
                Role = roleWriter,
                Email = "fake19@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "cac2178b-370c-4406-9f3d-15a96ac737fb.jpg"
                },
                Biography = new Biography
                {
                    Text = "Bill Bryson was born in Des Moines, Iowa. For twenty years he lived in England, where he worked for the Times and the Independent, and wrote for most major British and American publications. His books include travel memoirs (Neither Here Nor There; The Lost Continent; Notes from a Small Island) and books on language (The Mother Tongue; Made in America). His account of his attempts to walk the Appalachian Trail, A Walk in the Woods, was a huge New York Times bestseller. He lives in Hanover, New Hampshire, with his wife and his four children."
                }
            };

            Context.Users.Add(userBill);

            var userArthur = new User
            {
                FirstName = "Sir Arthur Conan",
                LastName = "Doyle",
                Username = "SirArthur",
                Address = address17,
                Role = roleWriter,
                Email = "fake20@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "9817b5b9-f641-4a2d-a2ab-d09b8f0e52ad.jpg"
                },
                Biography = new Biography
                {
                    Text = "Sir Arthur Conan Doyle was born in Edinburgh in 1859 and died in 1930. Within those years was crowded a variety of activity and creative work that made him an international figure and inspired the French to give him the epithet \'the good giant\'. He was the nephew of \'Dickie Doyle\' the artist, and was educated at Stonyhurst, and later studied medicine at Edinburgh University, where the methods of diagnosis of one of the professors provided the idea for the methods of deduction used by Sherlock Holmes."
                }
            };

            Context.Users.Add(userArthur);

            var userAgatha = new User
            {
                FirstName = "Agatha",
                LastName = "Christie",
                Username = "AgathaChristie",
                Address = address18,
                Role = roleWriter,
                Email = "fake21@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "b4982e83-fa2f-4386-a748-38844778a776.jpg"
                },
                Biography = new Biography
                {
                    Text = "Born in Torquay in 1890, Agatha Christie began writing during the First World War and wrote over 100 novels, plays and short story collections. She was still writing to great acclaim until her death, and her books have now sold over a billion copies in English and another billion in over 100 foreign languages. Yet Agatha Christie was always a very private person, and though Hercule Poirot and Miss Marple became household names, the Queen of Crime was a complete enigma to all but her closest friends."
                }
            };

            Context.Users.Add(userAgatha);

            var userMichael = new User
            {
                FirstName = "Michael",
                LastName = "Lewis",
                Username = "MichaelLewis",
                Address = address19,
                Role = roleWriter,
                Email = "fake22@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "155c903c-8e7f-45b6-84f7-0fd524ff7ffb.jpg"
                },
                Biography = new Biography
                {
                    Text = "Michael Lewis, the best-selling author of The Undoing Project, Liar\'s Poker, Flash Boys, Moneyball, The Blind Side, Home Game and The Big Short, among other works, lives in Berkeley, California, with his wife, Tabitha Soren, and their three children."
                }
            };

            Context.Users.Add(userMichael);

            var userMalcolm = new User
            {
                FirstName = "Malcolm",
                LastName = "Gladwell",
                Username = "MalcolmGladwell",
                Address = address20,
                Role = roleWriter,
                Email = "fake23@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password.123"),
                Phone = "0123456789",
                Token = TokenGenerator.GenerateRandomToken(30),
                EmailVerifiedAt = DateTime.Now,
                Avatar = new Image
                {
                    Alt = "Avatar",
                    Src = "cdebb111-a21b-45cd-a1fe-ff7b4625e96a.jpg"
                },
                Biography = new Biography
                {
                    Text = "Malcolm Gladwell has been a staff writer at The New Yorker since 1996. He is the author of The Tipping Point, Blink, Outliers, and What the Dog Saw. Prior to joining The New Yorker, he was a reporter at the Washington Post. Gladwell was born in England and grew up in rural Ontario. He now lives in New York."
                }
            };

            Context.Users.Add(userMalcolm);

            #endregion

            #region Book Seed

            var book1 = new Book
            {
                Title = "Murder on the Orient Express",
                PageCount = 289,
                Price = 17.99m,
                Prices = new List<Price>
                {
                    new Price
                    {
                        Value = 15.99m
                    },
                    new Price
                    {
                        Value = 17.99m
                    }
                },
                ReleaseDate = new DateTime(2011, 1, 18),
                Description = "THE MOST WIDELY READ MYSTERY OF ALL TIME-NOW A MAJOR MOTION PICTURE DIRECTED BY KENNETH BRANAGH AND PRODUCED BY RIDLEY SCOTT!\r\n\r\n\"The murderer is with us-on the train now . . .\"\r\n\r\nJust after midnight, the famous Orient Express is stopped in its tracks by a snowdrift. By morning, the millionaire Samuel Edward Ratchett lies dead in his compartment, stabbed a dozen times, his door locked from the inside. Without a shred of doubt, one of his fellow passengers is the murderer.\r\n",
                Author = userAgatha,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "1.jpg"
                },
                Categories = new List<Category> { categoryChildrenDetectiveMistery },
            };

            Context.Books.Add(book1);

            var book2 = new Book
            {
                Title = "And Then There Were None",
                PageCount = 303,
                Price = 16.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 13.99m
                    },
                    new Price
                    {
                        Value = 16.99m
                    }
                },
                ReleaseDate = new DateTime(2011,3,26),
                Description = "If you\\'re one of the few who haven\\'t experienced the genius of Agatha Christie, this novel is a stellar starting point.\" - DAVID BALDACCI, #1 New York Times Bestselling Author\r\n\r\nAn exclusive authorized edition of the most famous and beloved stories from the Queen of Mystery.\r\n\r\nTen people, each with something to hide and something to fear, are invited to an isolated mansion on Indian Island by a host who, surprisingly, fails to appear. On the island they are cut off from everything but each other and the inescapable shadows of their own past lives. One by one, the guests share the darkest secrets of their wicked pasts. And one by one, they die…",
                Author = userAgatha,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "2.jpg"
                },
                Categories = new List<Category> { categoryChildrenThrillersMistery },
            };

            Context.Books.Add(book2);

            var book3 = new Book
            {
                Title = "The Murder of Roger Ackroyd",
                PageCount = 306,
                Price = 15.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 10.99m
                    },
                    new Price
                    {
                        Value = 15.00m
                    }
                },
                ReleaseDate = new DateTime(2018, 12, 31),
                Description = "The Murder of Roger Ackroyd is a work of detective fiction by British writer Agatha Christie, first published in June 1926 in the United Kingdom. It is the third novel to feature Hercule Poirot as the lead detective.\r\n\r\nIn 2013, the British Crime Writers\\' Association voted it the best crime novel ever.",
                Author = userAgatha,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "3.jpg"
                },
                Categories = new List<Category> { categoryChildrenDetectiveMistery },
            };

            Context.Books.Add(book3);

            var book4 = new Book
            {
                Title = "Midwinter Murder",
                PageCount = 306,
                Price = 31.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 25.99m
                    },
                    new Price
                    {
                        Value = 31.99m
                    }
                },
                ReleaseDate = new DateTime(2020, 7, 4),
                Description = "\"Reading a perfectly plotted Agatha Christie is like crunching into a perfect apple: that pure, crisp, absolute satisfaction.\" -Tana French, New York Times bestselling author of the Dublin Murder Squad novels\r\n\r\nAn all-new collection of winter-themed stories from the Queen of Mystery, just in time for the holidays-including the original version of \"Christmas Adventure,\" never before released in the United States!\r\nThere\\'s a chill in the air and the days are growing shorter . . . It\\'s the perfect time to curl up in front of a crackling fire with these wintry whodunits from the legendary Agatha Christie. But beware of deadly snowdrifts and dangerous gifts, poisoned meals and mysterious guests. This chilling compendium of short stories-some featuring beloved detectives Hercule Poirot and Miss Marple-is an essential omnibus for Christie fans and the perfect holiday gift for mystery lovers.\r\n",
                Author = userAgatha,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "4.jpg"
                },
                Categories = new List<Category> 
                { 
                    categoryChildrenDetectiveMistery,
                    categoryChildrenThrillersMistery
                },
            };

            Context.Books.Add(book4);

            var book5 = new Book
            {
                Title = "The Mysterious Affair at Styles",
                PageCount = 185,
                Price = 9.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 5.99m
                    },
                    new Price
                    {
                        Value = 9.99m
                    }
                },
                ReleaseDate = new DateTime(2020, 1, 2),
                Description = "One morning at Styles Court, an Essex country manor, the elderly owner is found dead of strychnine poisoning. Arthur Hastings, a soldier staying there on sick leave from the Western Front, ventures out to the nearby village of Styles St. Mary to ask help from his friend Hercule Poirot, an eccentric Belgian inspector. Thus, in this classic whodunit, one of the most famous characters in detective fiction makes his debut on the world stage. With a half dozen suspects who all harbor secrets, it takes all of Poirot\'s prodigious sleuthing skills to untangle the mystery-but not before the inquiry undergoes scores of spellbinding twists and surprises. Contains the original illustrations and a detailed biography.",
                Author = userAgatha,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "5.jpg"
                },
                Categories = new List<Category> 
                {
                    categoryChildrenThrillersMistery,
                    categoryChildrenDetectiveMistery
                },
            };

            Context.Books.Add(book5);

            var book6 = new Book
            {
                Title = "Death on the Nile",
                PageCount = 320,
                Price = 14.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 10.99m
                    },
                    new Price
                    {
                        Value = 14.00m
                    }
                },
                ReleaseDate = new DateTime(2005, 6, 3),
                Description = "\"A top-notch literary brainteaser.\" -New York Times\r\n\r\nSoon to be a major motion picture sequel to Murder on the Orient Express with a screenplay by Michael Green, directed by and starring Kenneth Branagh alongside Gal Gadot-coming February 11, 2022!\r\n\r\nThe tranquility of a luxury cruise along the Nile was shattered by the discovery that Linnet Ridgeway had been shot through the head. She was young, stylish, and beautiful. A girl who had everything . . . until she lost her life",
                Author = userAgatha,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "6.jpg"
                },
                Categories = new List<Category> 
                {
                    categoryChildrenThrillersMistery
                },
            };

            Context.Books.Add(book6);

            var book7 = new Book
            {
                Title = "The Murder at the Vicarage",
                PageCount = 305,
                Price = 29.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 25.99m
                    },
                    new Price
                    {
                        Value = 29.99m
                    }
                },
                ReleaseDate = new DateTime(2009, 3, 15),
                Description = "The Murder at the Vicarage is Agatha Christie\\'s first mystery to feature the beloved investigator Miss Marple-as a dead body in a clergyman\\'s study proves to the indomitable sleuth that no place, holy or otherwise, is a sanctuary from homicide.\r\n\r\nMiss Marple encounters a compelling murder mystery in the sleepy little village of St. Mary Mead, where under the seemingly peaceful exterior of an English country village lurks intrigue, guilt, deception and death.\r\n\r\n\r\nColonel Protheroe, local magistrate and overbearing land-owner is the most detested man in the village. Everyone--even in the vicar--wishes he were dead. And very soon he is--shot in the head in the vicar\\'s own study. Faced with a surfeit of suspects, only the inscrutable Miss Marple can unravel the tangled web of clues that will lead to the unmasking of the killer.",
                Author = userAgatha,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "7.jpg"
                },
                Categories = new List<Category> 
                {
                    categoryChildrenDetectiveMistery
                },
            };

            Context.Books.Add(book7);

            var book8 = new Book
            {
                Title = "The Hollow",
                PageCount = 272,
                Price = 18.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 15.99m
                    },
                    new Price
                    {
                        Value = 18.00m
                    }
                },
                ReleaseDate = new DateTime(2006, 7, 4),
                Description = "Agatha Christie\\'s classic, The Hollow, finds Poirot entangled in a nasty web of family secrets when he comes across a fresh murder at an English country manor.\r\n\r\nA far-from-warm welcome greets Hercule Poirot as he arrives for lunch at Lucy Angkatell\\'s country house. A man lies dying by the swimming pool, his blood dripping into the water. His wife stands over him, holding a revolver.\r\n\r\nAs Poirot investigates, he begins to realize that beneath the respectable surface lies a tangle of family secrets and everyone becomes a suspect.",
                Author = userAgatha,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "8.jpg"
                },
                Categories = new List<Category> 
                {
                    categoryChildrenThrillersMistery
                },
            };

            Context.Books.Add(book8);

            var book9 = new Book
            {
                Title = "A Murder Is Announced",
                PageCount = 240,
                Price = 27.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 25.99m
                    },
                    new Price
                    {
                        Value = 27.00m
                    }
                },
                ReleaseDate = new DateTime(2009, 6, 18),
                Description = "The villagers of Chipping Cleghorn, including Jane Marple, are agog with curiosity over an advertisement in the local gazette which read: \'A murder is announced and will take place on Friday October 29th, at Little Paddocks at 6:30 p.m.\' Unable to resist the mysterious invitation, a crowd begins to gather at Little Paddocks at the pointed time when, without warning, the lights go out ...",
                Author = userAgatha,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "9.jpg"
                },
                Categories = new List<Category> 
                {
                    categoryChildrenDetectiveMistery
                },
            };

            Context.Books.Add(book9);

            var book10 = new Book
            {
                Title = "Sparkling Cyanide",
                PageCount = 288,
                Price = 9.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 5.99m
                    },
                    new Price
                    {
                        Value = 9.99m
                    }
                },
                ReleaseDate = new DateTime(2009, 3, 26),
                Description = "In Sparkling Cyanide, Agatha Christie seats six-including a murderer-around a dining table set for seven, one year to the day that a beautiful heiress was poisoned in that very room.\r\n\r\nSix people sit down to a sumptuous meal at a table laid for seven. In front of the empty place is a sprig of rosemary-\\\\\"rosemary for remembrance.\\\\\" A strange sentiment considering no one is likely to forget the night, exactly a year ago, that Rosemary Barton died at exactly the same table, her beautiful face unrecognizable, convulsed with pain and horror.\r\n\r\nBut then Rosemary had always been memorable-she had the ability to arouse strong passions in most people she met. In one case, strong enough to kill. . . .",
                Author = userAgatha,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "10.jpg"
                },
                Categories = new List<Category> 
                {
                    categoryChildrenDetectiveMistery
                },
            };

            Context.Books.Add(book10);

            var book11 = new Book
            {
                Title = "The Adventures Of Sherlock Holmes",
                PageCount = 148,
                Price = 10.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 5.99m
                    },
                    new Price
                    {
                        Value = 10.00m
                    }
                },
                ReleaseDate = new DateTime(2022, 3, 11),
                Description = "The Adventures of Sherlock Holmes is a collection of twelve short stories by Arthur Conan Doyle, first published on 14 October 1892. It contains the earliest short stories featuring the consulting detective Sherlock Holmes, which had been published in twelve monthly issues of The Strand Magazine from July 1891 to June 1892. The stories are collected in the same sequence, which is not supported by any fictional chronology. The only characters common to all twelve are Holmes and Dr. Watson and all are related in first-person narrative from Watson\\'s point of view.\r\n\r\nIn general the stories in The Adventures of Sherlock Holmes identify, and try to correct, social injustices. Holmes is portrayed as offering a new, fairer sense of justice. The stories were well received, and boosted the subscriptions figures of The Strand Magazine, prompting Doyle to be able to demand more money for his next set of stories. The first story, \\\\\"A Scandal in Bohemia\\\\\", includes the character of Irene Adler, who, despite being featured only within this one story by Doyle, is a prominent character in modern Sherlock Holmes adaptations, generally as a love interest for Holmes. Doyle included four of the twelve stories from this collection in his twelve favourite Sherlock Holmes stories, picking \"The Adventure of the Speckled Band\" as his overall favourite.\r\n\r\n",
                Author = userArthur,
                Publisher = publisherGrapevine,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "11.jpg"
                },
                Categories = new List<Category> 
                {
                    categoryChildrenDetectiveMistery
                },
            };

            Context.Books.Add(book11);

            var book12 = new Book
            {
                Title = "The Hound of the Baskervilles",
                PageCount = 208,
                Price = 9.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 5.99m
                    },
                    new Price
                    {
                        Value = 9.99m
                    }
                },
                ReleaseDate = new DateTime(2019, 6, 23),
                Description = "The Hound of the Baskervilles is the third of the four crime novels written by Sir Arthur Conan Doyle featuring the detective Sherlock Holmes. Originally serialised in The Strand Magazine from August 1901 to April 1902, it is set largely on Dartmoor in Devon in England\\'s West Country and tells the story of an attempted murder inspired by the legend of a fearsome, diabolical hound of supernatural origin. Sherlock Holmes and his companion Dr. Watson investigate the case. This was the first appearance of Holmes since his apparent death in \"The Final Problem\", and the success of The Hound of the Baskervilles led to the character\\'s eventual revival.",
                Author = userArthur,
                Publisher = publisherGrapevine,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "12.jpg"
                },
                Categories = new List<Category> 
                {
                    categoryChildrenThrillersMistery
                },
            };

            Context.Books.Add(book12);

            var book13 = new Book
            {
                Title = "A Study in Scarlet",
                PageCount = 142,
                Price = 6.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 4.99m
                    },
                    new Price
                    {
                        Value = 6.00m
                    }
                },
                ReleaseDate = new DateTime(2018, 4, 3),
                Description = "A Study in Scarlet first appeared in 1887 in Beeton\\'s Christmas Annual and was marked the first appearance of Sherlock Holmes and Dr. Watson, who would become the most famous detective duo in popular fiction. The book\\'s title derives from a speech given by Holmes, a consulting detective, to his friend and chronicler Watson on the nature of his work, in which he describes the story\\'s murder investigation as his \\\\\"study in scarlet\\\\\". The story, and its main characters, attracted little public interest when it first appeared. This book is the first of four full-length novels about Holmes. Doyle\\'s other works were collections of short stories.",
                Author = userArthur,
                Publisher = publisherGrapevine,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "13.jpg"
                },
                Categories = new List<Category> 
                {
                    categoryChildrenThrillersMistery
                },
            };

            Context.Books.Add(book13);

            var book14 = new Book
            {
                Title = "The Memoirs of Sherlock Holmes",
                PageCount = 276,
                Price = 16.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 16.00m
                    }
                },
                ReleaseDate = new DateTime(2019, 7, 3),
                Description = "The Memoirs of Sherlock Holmes is a collection of Sherlock Holmes stories, originally published in 1893, by Arthur Conan Doyle. Doyle had decided that these would be the last collection of Holmes\\'s stories, and intended to kill him off in the last adventure \\\\\"The Final Problem\\\\\". Readers wanted him to write more adventures featuring Sherlock Holmes, so Doyle released The Hound of the Baskervilles years later. He followed that up with The Return of Sherlock Holmes, in which Holmes relates how he survived.",
                Author = userArthur,
                Publisher = publisherGrapevine,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "14.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenThrillersMistery,
                    categoryChildrenDetectiveMistery
                }
            };
            
            Context.Books.Add(book14);

            var book15 = new Book
            {
                Title = "The Sign of Four",
                PageCount = 126,
                Price = 15.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 12.99m
                    },
                    new Price
                    {
                        Value = 15.00m
                    }
                },
                ReleaseDate = new DateTime(2021, 9, 7),
                Description = "A nice edition with the first edition cover and 13 original illustrations.\r\n\r\nThe Sign of Four was first released to magazines in 1890. It was later published in book format and is also known by the title The Sign of the Four. It is the second Sherlock Holmes novel, after A Study in Scarlet. The plot involves service in India, the Indian Rebellion of 1857, a stolen treasure, and a secret pact among four convicts (\\\\\"the Four\\\\\" of the title) and two corrupt prison guards... and of course, Sherlock Holmes.",
                Author = userArthur,
                Publisher = publisherGrapevine,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "15.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenThrillersMistery
                }
            };

            Context.Books.Add(book15);

            var book16 = new Book
            {
                Title = "Notes from a Small Island",
                PageCount = 338,
                Price = 13.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 11.99m
                    },
                    new Price
                    {
                        Value = 13.00m
                    }
                },
                ReleaseDate = new DateTime(2015, 2, 3),
                Description = "Before New York Times bestselling author Bill Bryson wrote The Road to Little Dribbling, he took this delightfully irreverent jaunt around the unparalleled floating nation of Great Britain, which has produced zebra crossings, Shakespeare, Twiggie Winkie\'s Farm, and places with names like Farleigh Wallop and Titsey.",
                Author = userBill,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "16.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalTravel,
                    categoryChildrenAdventureTravel
                }
            };

            Context.Books.Add(book16);

            var book17 = new Book
            {
                Title = "A Short History of Nearly Everything",
                PageCount = 345,
                Price = 49.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 44.99m
                    },
                    new Price
                    {
                        Value = 49.99m
                    }
                },
                ReleaseDate = new DateTime(2003, 5, 1),
                Description = "One of the world\\'s most beloved writers and New York Times bestselling author of A Walk in the Woods and The Body takes his ultimate journey-into the most intriguing and intractable questions that science seeks to answer.\r\n\r\nIn A Walk in the Woods, Bill Bryson trekked the Appalachian Trail-well, most of it. In A Sunburned Country, he confronted some of the most lethal wildlife Australia has to offer. Now, in his biggest book, he confronts his greatest challenge: to understand-and, if possible, answer-the oldest, biggest questions we have posed about the universe and ourselves. Taking as territory everything from the Big Bang to the rise of civilization, Bryson seeks to understand how we got from there being nothing at all to there being us. To that end, he has attached himself to a host of the world\\'s most advanced (and often obsessed) archaeologists, anthropologists, and mathematicians, travelling to their offices, laboratories, and field camps. He has read (or tried to read) their books, pestered them with questions, apprenticed himself to their powerful minds. A Short History of Nearly Everything is the record of this quest, and it is a sometimes profound, sometimes funny, and always supremely clear and entertaining adventure in the realms of human knowledge, as only Bill Bryson can render it. Science has never been more involving or entertaining.",
                Author = userBill,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "17.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalTravel,
                    categoryChildrenThrillersMistery
                }
            };

            Context.Books.Add(book17);

            var book18 = new Book
            {
                Title = "A Walk in the Woods: Rediscovering America on the",
                PageCount = 305,
                Price = 38.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 34.99m
                    },
                    new Price
                    {
                        Value = 38.99m
                    }
                },
                ReleaseDate = new DateTime(2010, 8, 8),
                Description = "\"The best way of escaping into nature.\"-The New York Times\r\n\r\n Back in America after twenty years in Britain, Bill Bryson decided to reacquaint himself with his native country by walking the 2,100-mile Appalachian Trail, which stretches from Georgia to Maine. The AT offers an astonishing landscape of silent forests and sparkling lakes-and to a writer with the comic genius of Bill Bryson, it also provides endless opportunities to witness the majestic silliness of his fellow human beings.\r\n\r\nFor a start there\\'s the gloriously out-of-shape Stephen Katz, a buddy from Iowa along for the walk. But A Walk in the Woods is more than just a laugh-out-loud hike. Bryson\\'s acute eye is a wise witness to this beautiful but fragile trail, and as he tells its fascinating history, he makes a moving plea for the conservation of America\\'s last great wilderness. An adventure, a comedy, and a celebration, A Walk in the Woods is a modern classic of travel literature.",
                Author = userBill,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "18.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalTravel
                }
            };

            Context.Books.Add(book18);

            var book19 = new Book
            {
                Title = "In a Sunburned Country",
                PageCount = 335,
                Price = 29.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 24.99m
                    },
                    new Price
                    {
                        Value = 29.99m
                    }
                },
                ReleaseDate = new DateTime(2000, 1, 1),
                Description = "Every time Bill Bryson walks out the door, memorable travel literature threatens to break out. This time in Australia.\r\nHis previous excursion along the Appalachian Trail resulted in the sublime national bestseller A Walk in the Woods. In A Sunburned Country is his report on what he found in an entirely different place: Australia, the country that doubles as a continent, and a place with the friendliest inhabitants, the hottest, driest weather, and the most peculiar and lethal wildlife to be found on the planet. The result is a deliciously funny, fact-filled, and adventurous performance by a writer who combines humor, wonder, and unflagging curiousity.\r\n\r\nDespite the fact that Australia harbors more things that can kill you in extremely nasty ways than anywhere else, including sharks, crocodiles, snakes, even riptides and deserts, Bill Bryson adores the place, and he takes his readers on a rollicking ride far beyond that beaten tourist path. Wherever he goes he finds Australians who are cheerful, extroverted, and unfailingly obliging, and these beaming products of land with clean, safe cities, cold beer, and constant sunshine fill the pages of this wonderful book.\r\n",
                Author = userBill,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "19.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalTravel,
                    categoryChildrenAdventureTravel
                }
            };

            Context.Books.Add(book19);

            var book20 = new Book
            {
                Title = "The Road to Little Dribbling: Adventures of an Ame",
                PageCount = 382,
                Price = 27.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 24.99m
                    },
                    new Price
                    {
                        Value = 27.99m
                    }
                },
                ReleaseDate = new DateTime(2016, 1, 18),
                Description = "A loving and hilarious-if occasionally spiky-valentine to Bill Bryson\\'s adopted country, Great Britain. Prepare for total joy and multiple episodes of unseemly laughter.\r\n\r\nTwenty years ago, Bill Bryson went on a trip around Britain to discover and celebrate that green and pleasant land. The result was Notes from a Small Island, a true classic and one of the bestselling travel books ever written. Now he has traveled about Britain again, by bus and train and rental car and on foot, to see what has changed-and what hasn\\'t.\r\n\r\nFollowing (but not too closely) a route he dubs the Bryson Line, from Bognor Regis in the south to Cape Wrath in the north, by way of places few travelers ever get to at all, Bryson rediscovers the wondrously beautiful, magnificently eccentric, endearingly singular country that he both celebrates and, when called for, twits. With his matchless instinct for the funniest and quirkiest and his unerring eye for the idiotic, the bewildering, the appealing, and the ridiculous, he offers acute and perceptive insights into all that is best and worst about Britain today.",
                Author = userBill,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "20.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalTravel
                }
            };

            Context.Books.Add(book20);

            var book21 = new Book
            {
                Title = "One Summer: America, 1927",
                PageCount = 545,
                Price = 16.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 16.00m
                    }
                },
                ReleaseDate = new DateTime(2013, 9, 4),
                Description = "In One Summer Bill Bryson, one of our greatest and most beloved nonfiction writers, transports readers on a journey back to one amazing season in American life.\r\n\r\nThe summer of 1927 began with one of the signature events of the twentieth century: on May 21, 1927, Charles Lindbergh became the first man to cross the Atlantic by plane nonstop, and when he landed in Le Bourget airfield near Paris, he ignited an explosion of worldwide rapture and instantly became the most famous person on the planet. Meanwhile, the titanically talented Babe Ruth was beginning his assault on the home run record, which would culminate on September 30 with his sixtieth blast, one of the most resonant and durable records in sports history. In between those dates a Queens housewife named Ruth Snyder and her corset-salesman lover garroted her husband, leading to a murder trial that became a huge tabloid sensation\r\n\r\nAlvin \"Shipwreck\" Kelly sat atop a flagpole in Newark, New Jersey, for twelve days-a new record. The American South was clobbered by unprecedented rain and by flooding of the Mississippi basin, a great human disaster, the relief efforts for which were guided by the uncannily able and insufferably pompous Herbert Hoover. Calvin Coolidge interrupted an already leisurely presidency for an even more relaxing three-month vacation in the Black Hills of South Dakota.",
                Author = userBill,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "21.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalTravel,
                    categoryChildrenSocialHistory,
                    categoryChildrenCulturalHistory
                }
            };

            Context.Books.Add(book21);

            var book22 = new Book
            {
                Title = "I\'m a Stranger Here Myself: Notes on Returning to ",
                PageCount = 306,
                Price = 21.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 18.99m
                    },
                    new Price
                    {
                        Value = 21.00m
                    }
                },
                ReleaseDate = new DateTime(2008, 6, 13),
                Description = "A classic from the New York Times bestselling author of A Walk in the Woods and The Body.\r\n\r\nAfter living in Britain for two decades, Bill Bryson recently moved back to the United States with his English wife and four children (he had read somewhere that nearly 3 million Americans believed they had been abducted by aliens-as he later put it, \\\\\"it was clear my people needed me\\\\\"). They were greeted by a new and improved America that boasts microwave pancakes, twenty-four-hour dental-floss hotlines, and the staunch conviction that ice is not a luxury item.\r\n\r\nDelivering the brilliant comic musings that are a Bryson hallmark, I\\'m a Stranger Here Myself recounts his sometimes disconcerting reunion with the land of his birth. The result is a book filled with hysterical scenes of one man\\'s attempt to reacquaint himself with his own country, but it is also an extended if at times bemused love letter to the homeland he has returned to after twenty years away.",
                Author = userBill,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "22.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenAdventureTravel,
                    categoryChildrenCulturalTravel
                }
            };

            Context.Books.Add(book22);

            var book23 = new Book
            {
                Title = "Bill Bryson\'s African Diary",
                PageCount = 66,
                Price = 22.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 20.99m
                    },
                    new Price
                    {
                        Value = 22.99m
                    }
                },
                ReleaseDate = new DateTime(2007, 12, 15),
                Description = "From the author of A Short History of Nearly Everything and The Body comes a travel diary documenting a visit to Kenya. All royalties and profits go to CARE International.\r\n\r\nIn the early fall of 2002, famed travel writer Bill Bryson journeyed to Kenya at the invitation of CARE International, the charity dedicated to working with local communities to eradicate poverty around the world. He arrived with a set of mental images of Africa gleaned from television broadcasts of low-budget Jungle Jim movies in his Iowa childhood and a single viewing of the film version of Out of Africa. (Also with some worries about tropical diseases, insects, and large predators.) But the vibrant reality of Kenya and its people took over the second he deplaned in Nairobi, and this diary records Bill Bryson\\'s impressions of his trip with his inimitable trademark style of wry observation and curious insight.\r\n\r\nFrom the wrenching poverty of the Kibera slum in Nairobi to the meticulously manicured grounds of the Karen Blixen house and the human fossil riches of the National Museum, Bryson registers the striking contrasts of a postcolonial society in transition. He visits the astoundingly vast Great Rift Valley; undergoes the rigors of a teeth-rattling train journey to Mombasa and a hair-whitening flight through a vicious storm; and visits the refugee camps and the agricultural and economic projects where dedicated CARE professionals wage noble and dogged war against poverty, dislocation, and corruption.",
                Author = userBill,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "23.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalTravel,
                    categoryChildrenAdventureTravel
                }
            };

            Context.Books.Add(book23);

            var book24 = new Book
            {
                Title = "Neither here nor there: Travels in Europe",
                PageCount = 322,
                Price = 49.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 44.99m
                    },
                    new Price
                    {
                        Value = 49.99m
                    }
                },
                ReleaseDate = new DateTime(2015, 4, 14),
                Description = "In the early seventies, Bill Bryson backpacked across Europe-in search of enlightenment, beer, and women. He was accompanied by an unforgettable sidekick named Stephen Katz (who will be gloriously familiar to readers of Bryson\\'s A Walk in the Woods). Twenty years later, he decided to retrace his journey. The result is the affectionate and riotously funny Neither Here Nor There.\r\n\r\n",
                Author = userBill,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "24.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenAdventureTravel
                }
            };

            Context.Books.Add(book24);

            var book25 = new Book
            {
                Title = "The Lost Continent: Travels in Small Town America",
                PageCount = 354,
                Price = 14.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 12.99m
                    },
                    new Price
                    {
                        Value = 14.99m
                    }
                },
                ReleaseDate = new DateTime(2011, 3, 26),
                Description = "An inspiring and hilarious account of one man\\'s rediscovery of America and his search for the perfect small town.\r\n\r\nFollowing an urge to rediscover his youth, Bill Bryson left his native Des Moines, Iowa, in a journey that would take him across 38 states. Lucky for us, he brought a notebook. With a razor wit and a kind heart, Bryson serves up a colorful tale of boredom, kitsch, and beauty when you least expect it. From Times Square to the Mississippi River to Williamsburg, Virginia, Bryson\\'s keen and hilarious search for the perfect American small town is a journey straight into the heart and soul of America.",
                Author = userBill,
                Publisher = publisherWilliam,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "25.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenAdventureTravel
                }
            };

            Context.Books.Add(book25);

            var book26 = new Book
            {
                Title = "The Great Railway Bazaar",
                PageCount = 354,
                Price = 15.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 12.99m
                    },
                    new Price
                    {
                        Value = 15.00m
                    }
                },
                ReleaseDate = new DateTime(2006, 5, 1),
                Description = "The acclaimed author recounts his epic journey across Europe and Asia in this international bestselling classic of travel literature: \"Compulsive reading\" (Graham Greene).\r\n\r\nIn 1973, Paul Theroux embarked on a four-month journey by train from the United Kingdom through Europe, the Middle East, and Southeast Asia. In The Great Railway Bazaar, he records in vivid detail and penetrating insight the many fascinating incidents, adventures, and encounters of his grand, intercontinental tour.\r\n\r\nAsia\\'s fabled trains-the Orient Express, the Khyber Pass Local, the Frontier Mail, the Golden Arrow to Kuala Lumpur, the Mandalay Express, the Trans-Siberian Express-are the stars of a journey that takes Theroux on a loop eastbound from London\\'s Victoria Station to Tokyo Central, then back from Japan on the Trans-Siberian. Brimming with Theroux\\'s signature humor and wry observations, this engrossing chronicle is essential reading for both the ardent adventurer and the armchair traveler.",
                Author = userPaul,
                Publisher = publisherMariner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "26.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenAdventureTravel,
                    categoryChildrenCulturalTravel
                }
            };

            Context.Books.Add(book26);

            var book27 = new Book
            {
                Title = "Deep South: Four Seasons on Back Roads",
                PageCount = 485,
                Price = 27.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 24.99m
                    },
                    new Price
                    {
                        Value = 27.99m
                    }
                },
                ReleaseDate = new DateTime(2011, 3, 26),
                Description = "The acclaimed author of The Great Railway Bazaar takes a revealing journey through the Southern US in a \"vivid contemporary portrait of rural life\" (Atlanta Journal-Constitution).\r\n\r\nPaul Theroux has spent decades roaming the globe and writing of his experiences with remote people and far-flung places. Now, for the first time, he turns his attention to a corner of America-the Deep South. On a winding road trip through Mississippi, South Carolina, and elsewhere below the Mason-Dixon, Theroux discovers architectural and artistic wonders, incomparable music, mouth-watering cuisine-and also some of the worst schools, medical care, housing, and unemployment rates in the nation.\r\n\r\nMost fascinating of all are Theroux\\'s many encounters with the people who make the South what it is-from preachers and mayors to quarry workers and gun show enthusiasts. With his astute ear and penetrating mind, Theroux once again demonstrates his \"remarkable gift for getting strangers to reveal themselves\" in this eye-opening excursion into his own country (The New York Times Book Review).",
                Author = userPaul,
                Publisher = publisherMariner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "27.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalTravel,
                    categoryChildrenAdventureTravel
                }
            };

            Context.Books.Add(book27);

            var book28 = new Book
            {
                Title = "The Happy Isles of Oceania: Paddling the Pacific",
                PageCount = 530,
                Price = 43.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 41.99m
                    },
                    new Price
                    {
                        Value = 43.00m
                    }
                },
                ReleaseDate = new DateTime(2006, 12, 1),
                Description = "The author of The Great Railway Bazaar explores the South Pacific by kayak: \"This exhilarating epic ranks with [his] best travel books\" (Publishers Weekly).\r\n\r\nIn one of his most exotic and adventuresome journeys, travel writer Paul Theroux embarks on an eighteen-month tour of the South Pacific, exploring fifty-one islands by collapsible kayak. Beginning in New Zealand\\'s rain forests and ultimately coming to shore thousands of miles away in Hawaii, Theroux paddles alone over isolated atolls, through dirty harbors and shark-filled waters, and along treacherous coastlines.\r\n\r\nAlong the way, Theroux meets the king of Tonga, encounters street gangs in Auckland, and investigates a cargo cult in Vanuatu. From Australia to Tahiti, Fiji, Easter Island, and beyond, this exhilarating tropical epic is full of disarming observations and high adventure.",
                Author = userPaul,
                Publisher = publisherMariner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "28.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenAdventureTravel
                }
            };

            Context.Books.Add(book28);

            var book29 = new Book
            {
                Title = "On The Plain Of Snakes: A Mexican Journey",
                PageCount = 542,
                Price = 21.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 15.99m
                    },
                    new Price
                    {
                        Value = 21.00m
                    }
                },
                ReleaseDate = new DateTime(2019, 6, 4),
                Description = "The legendary travel writer drives the entire length of the US-Mexico border, then takes the back roads of Chiapas and Oaxaca, to uncover the rich, layered world behind the everyday headlines.\r\n\r\nPaul Theroux has spent his life crisscrossing the globe in search of the histories and peoples that give life to the places they call home. Now, as immigration debates boil around the world, Theroux has set out to explore a country key to understanding our current discourse: Mexico. Just south of the Arizona border, in the desert region of Sonora, he finds a place brimming with vitality, yet visibly marked by both the US Border Patrol to the north and mounting discord from within. With the same humanizing sensibility that he employed in Deep South, Theroux stops to talk with residents, visits Zapotec mill workers in the highlands, and attends a Zapatista party meeting, communing with people of all stripes who remain south of the border even as family members brave the journey north.",
                Author = userPaul,
                Publisher = publisherMariner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "29.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalTravel
                }
            };

            Context.Books.Add(book29);

            var book30 = new Book
            {
                Title = "The Old Patagonian Express: By Train Through the A",
                PageCount = 506,
                Price = 47.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 44.99m
                    },
                    new Price
                    {
                        Value = 47.99m
                    }
                },
                ReleaseDate = new DateTime(2014, 6, 4),
                Description = "The acclaimed travel writer journeys by train across the Americas from Boston to Patagonia in this international bestselling travel memoir.\r\n\r\nStarting with a rush-hour subway ride to South Station in Boston to catch the Lake Shore Limited to Chicago, Paul Theroux takes a grand railway adventure first across the United States and then south through Mexico, Central America, and across the Andes until he winds up on the meandering Old Patagonian Express steam engine. His epic commute finally comes to a halt in a desolate land of cracked hills and thorn bushes that reaches toward Antarctica.\r\n\r\nAlong the way, Theroux demonstrates how train travel can reveal \"the social miseries and scenic splendors\" of a continent. And through his perceptive prose we learn that what matters most are the people he meets along the way, including the monologuing Mr. Thornberry in Costa Rica, the bogus priest of Cali, and the blind Jorge Luis Borges, who delights in having Theroux read Robert Louis Stevenson to him.",
                Author = userPaul,
                Publisher = publisherMariner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "30.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalTravel,
                    categoryChildrenAdventureTravel
                }
            };

            Context.Books.Add(book30);

            var book31 = new Book
            {
                Title = "How to Win Friends and Influence People",
                PageCount = 317,
                Price = 25.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 22.99m
                    },
                    new Price
                    {
                        Value = 25.99m
                    }
                },
                ReleaseDate = new DateTime(2022, 5, 17),
                Description = "Updated for the first time in more than forty years, Dale Carnegie\\'s timeless bestseller How to Win Friends and Influence People-a classic that has improved and transformed the personal and professional lives of millions.\r\n\r\nThis new edition of the most influential self-help book of the last century has been updated under the care of Dale\\'s daughter, Donna, introducing changes that keep the book fresh for today\\'s readers, with priceless material restored from the original 1936 text.\r\n\r\nOne of the best-known motivational guides in history, Dale Carnegie\\'s groundbreaking publication has sold tens of millions of copies, been translated into almost every known written language, and has helped countless people succeed.",
                Author = userDale,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "31.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCommunicationImprovement,
                    categoryChildrenPersonalImprovement,
                    categoryChildrenManagementBusiness
                }
            };

            Context.Books.Add(book31);

            var book32 = new Book
            {
                Title = "How to Stop Worrying & Start Living",
                PageCount = 399,
                Price = 15.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 12.99m
                    },
                    new Price
                    {
                        Value = 15.99m
                    }
                },
                ReleaseDate = new DateTime(2022, 5, 12),
                Description = "\"Let\\'s not allow ourselves to be upset by small things we should despise and forget. Remember \"Life is too short to belittle\" \"One of the most tragic things I know about human nature is that all of us tend to put off living. We are all dreaming of some magical rose garden over the horizon-instead of enjoying the roses that are blooming outside our windows today. Why are we such fools-such tragic fools?\" \"The most important thing in life is not to capitalize on your gains. Any fool can do that. The really important thing is to profit from your losses.\" -Dale Carnegie This enlightening self-book offers a detailed guide on how to manage your worries to lead a delightful life. More often than not our personal and professional relationships are the major cause of stress and anxiety. A best-seller of all times, this book will help you achieve your maximum potential in the complex and competitive modern age, without worrying about your associations and affiliations with others.",
                Author = userDale,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "32.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenManagementBusiness,
                    categoryChildrenCommunicationImprovement
                }
            };

            Context.Books.Add(book32);

            var book33 = new Book
            {
                Title = "The Art of Public Speaking: The Original Tool for ",
                PageCount = 532,
                Price = 43.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 41.99m
                    },
                    new Price
                    {
                        Value = 43.00m
                    }
                },
                ReleaseDate = new DateTime(2018, 6, 23),
                Description = "Do you have trouble getting up in front of an audience? Are you struggling to get your point across? Public speaking can be nerve-wracking, especially if you\'re a naturally nervous person or if you\'re underprepared. Originally published in 1915, The Art of Public Speaking has been the go-to guide for those who want to better their speaking abilities for more than a century.",
                Author = userDale,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "33.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenPersonalImprovement,
                    categoryChildrenCommunicationImprovement
                }
            };

            Context.Books.Add(book33);

            var book34 = new Book
            {
                Title = "Take Command",
                PageCount = 267,
                Price = 14.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 11.99m
                    },
                    new Price
                    {
                        Value = 14.99m
                    }
                },
                ReleaseDate = new DateTime(2023, 1, 4),
                Description = "Take command of your future with this groundbreaking book from the experts who brought you How to Win Friends and Influence People.\r\n\r\nTake Command offers powerful tools and time-tested methods to help you live an intentional life by transforming how you approach your thoughts, emotions, relationships, and future. Filled with stories of everyday people and based on expert research and interviews with more than a hundred high-performing leaders, Take Command gives you the strategies you need to unlock your full potential and create the life you want.",
                Author = userDale,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "34.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenPersonalImprovement
                }
            };

            Context.Books.Add(book34);

            var book35 = new Book
            {
                Title = "The Quick and Easy Way to Effective Speaking",
                PageCount = 185,
                Price = 45.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 42.99m
                    },
                    new Price
                    {
                        Value = 45.99m
                    }
                },
                ReleaseDate = new DateTime(2019, 5, 19),
                Description = "Good public speakers are made-not born. Public speaking is an important skill which anyone can acquire and develop. This book that has literally put millions on the highway to greater accomplishment and success can show you how to have maximum impact as a speaker. It will help you to acquire basic public speaking skills, building confidence, earning the right to talk, sharing the talk with the audience.",
                Author = userDale,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "35.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCommunicationImprovement
                }
            };

            Context.Books.Add(book35);

            var book36 = new Book
            {
                Title = "Listen!: The Art of Effective Communication",
                PageCount = 224,
                Price = 18.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 13.99m
                    },
                    new Price
                    {
                        Value = 18.99m
                    }
                },
                ReleaseDate = new DateTime(2018, 7, 3),
                Description = "Why do we so often fail to connect when speaking with business colleagues, family members, or friends? Wouldn\\'t you like to make yourself heard and understood in all of your relationships?\r\n\r\nUsing vivid examples, easy-to-learn techniques, and practical exercises for becoming a better listener-and making yourself heard and understood, Dale Carnegie will show you how it\\'s done, even in difficult situations.\r\n\r\nFounded in 1912, Dale Carnegie Training has evolved from one man\\'s belief in the power of self-improvement to a performance-based training company with offices worldwide. Dale Carnegie\\'s original body of knowledge has been constantly updated, expanded and refined through nearly a century\\'s worth of real-life business experiences. He is recognized internationally as the leader in bringing out the best in people and over 8 million people have completed a Dale Carnegie course.",
                Author = userDale,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "36.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCommunicationImprovement
                }
            };

            Context.Books.Add(book36);

            var book37 = new Book
            {
                Title = "Make Yourself Unforgettable",
                PageCount = 175,
                Price = 52.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 48.99m
                    },
                    new Price
                    {
                        Value = 52.99m
                    }
                },
                ReleaseDate = new DateTime(2011, 2, 7),
                Description = "From one of the most trusted and bestselling brands in business training, Make Yourself Unforgettable reveals how to develop and embody unforgettable qualities so you can become the effective and desirable colleague and friend possible.\r\n\r\nLearn how to develop and embody the ten essential elements of being unforgettable!\r\n\r\nWhat does it really mean to have class? How do you distinguish yourself from the crowd and become a successful leader? When should intuition guide your business decisions? The answers to these and other important questions can be found in this dynamic and inspiring guidebook for anyone looking to lead a life of greater meaning and influence.",
                Author = userDale,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "37.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenPersonalImprovement
                }
            };

            Context.Books.Add(book37);

            var book38 = new Book
            {
                Title = "How To Develop Self-Confidence & Influence People",
                PageCount = 260,
                Price = 63.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 60.99m
                    },
                    new Price
                    {
                        Value = 63.00m
                    }
                },
                ReleaseDate = new DateTime(2021, 3, 1),
                Description = "Dale Carnegie\'s How to Develop-Self Confidence & Influence People is an evergreen work. The main takeaway from this book is that improving public speaking and improving self-confidence are a function of preparation, education, determination and practice. There is no short cut to a better you - rather a long path of self-improvement.",
                Author = userDale,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "38.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenPersonalImprovement
                }
            };

            Context.Books.Add(book38);

            var book39 = new Book
            {
                Title = "How to Stop Worrying and Start Living",
                PageCount = 734,
                Price = 16.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 16.00m
                    }
                },
                ReleaseDate = new DateTime(2021, 8, 12),
                Description = "How To Stop Worrying and Start Living is a self-help book by Dale Carnegie. Carnegie is considered to be one of the greatest self-help experts, he mentions in the preface that he wrote it because he \"was one of the unhappiest lads in New York\". He says that he made himself sick with worry because he hated his position in life, which he attributes to wanting to figure out how to stop worrying.\r\n\r\nThe book\\'s goal is to lead the reader to a more enjoyable and fulfilling lifestyle, helping them to become more aware of, not only themselves, but others also around them. Carnegie tries to address the everyday nuances of living, in order to get the reader to focus on the more important aspects of life.",
                Author = userDale,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "39.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenPersonalImprovement
                }
            };

            Context.Books.Add(book39);

            var book40 = new Book
            {
                Title = "3 Steps to Being a Great Manager",
                PageCount = 614,
                Price = 33.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 34.99m
                    },
                    new Price
                    {
                        Value = 33.99m
                    }
                },
                ReleaseDate = new DateTime(2021, 8, 5),
                Description = "Why do we so often fail to connect when speaking with others? Wouldn\\'t you like to make yourself heard and understood? Using vivid examples, easy-to-learn techniques, and practical exercises for becoming a better listener-and making yourself heard and understood, Dale Carnegie will show you how it\\'s done, even in difficult situations.\r\n\r\nToday, where media is social and funding is raised by crowds, the sales cycle has permanently changed. It\\'s not enough to know your product, nor always appropriate to challenge your customer\\'s thinking based on your research. Dale Carnegie & Associates reveal the REAL modern sales cycle that depends on your ability to influence more than just one buyer, understand what today\\'s customers want, and use time-tested principles to strengthen relationships anywhere in the global economy.",
                Author = userDale,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "40.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenPersonalImprovement,
                    categoryChildrenManagementBusiness
                }
            };

            Context.Books.Add(book40);

            var book41 = new Book
            {
                Title = "Life Force",
                PageCount = 700,
                Price = 25.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 22.99m
                    },
                    new Price
                    {
                        Value = 25.99m
                    }
                },
                ReleaseDate = new DateTime(2022, 2, 8),
                Description = "Transform your life or the life of someone you love with Life Force-the newest breakthroughs in health technology to help maximize your energy and strength, prevent disease, and extend your health span-from Tony Robbins, author of the #1 New York Times bestseller Money: Master the Game.\r\n\r\nWhat if there were scientific solutions that could wipe out your deepest fears of falling ill, receiving a life-threatening diagnosis, or feeling the effects of aging? What if you had access to the same cutting-edge tools and technology used by peak performers and the world\\'s greatest athletes?\r\n\r\nIn a world full of fear and uncertainty about our health, it can be difficult to know where to turn for actionable advice you can trust. Today, leading scientists and doctors in the field of regenerative medicine are developing diagnostic tools and safe and effective therapies that can free you from fear.",
                Author = userTony,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "41.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenPersonalImprovement
                }
            };

            Context.Books.Add(book41);

            var book42 = new Book
            {
                Title = "MONEY Master the Game: 7 Simple Steps to Financial",
                PageCount = 689,
                Price = 66.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 64.99m
                    },
                    new Price
                    {
                        Value = 66.00m
                    }
                },
                ReleaseDate = new DateTime(2014, 9, 18),
                Description = "Tony Robbins turns to the topic that vexes us all: How to secure financial freedom for ourselves and for our families. \"If there were a Pulitzer Prize for investment books, this one would win, hands down\" (Forbes).\r\n\r\nTony Robbins is one of the most revered writers and thinkers of our time. People from all over the world-from the disadvantaged to the well-heeled, from twenty-somethings to retirees-credit him for giving them the inspiration and the tools for transforming their lives. From diet and fitness, to business and leadership, to relationships and self-respect, Tony Robbins\\'s books have changed people in profound and lasting ways. Now, for the first time, he has assembled an invaluable \"distillation of just about every good personal finance idea of the last forty years\" (The New York Times).\r\n\r\nBased on extensive research and interviews with some of the most legendary investors at work today (John Bogle, Warren Buffett, Paul Tudor Jones, Ray Dalio, Carl Icahn, and many others), Tony Robbins has created a 7-step blueprint for securing financial freedom. With advice about taking control of your financial decisions, to setting up a savings and investing plan, to destroying myths about what it takes to save and invest, to setting up a \"lifetime income plan,\" the book brims with advice and practices for making the financial game not only winnable-but providing financial freedom for the rest of your life. \"Put MONEY on your short list of new books to read…It\\'s that good\" (Marketwatch.com).",
                Author = userTony,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "42.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenPersonalImprovement,
                    categoryChildrenManagementBusiness,
                    categoryChildrenFinanceBusiness
                }
            };

            Context.Books.Add(book42);

            var book43 = new Book
            {
                Title = "Unshakeable: Your Financial Freedom Playbook",
                PageCount = 257,
                Price = 43.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 40.99m
                    },
                    new Price
                    {
                        Value = 43.00m
                    }
                },
                ReleaseDate = new DateTime(2017, 2, 5),
                Description = "Transform your financial life and accelerate your path to financial freedom with this step-by-step playbook to achieving your financial goals from the #1 New York Times bestseller of Money: Master the Game, Tony Robbins.\r\n\r\nRobbins, who has coached more than fifty million people from 100 countries, is the world\\'s #1 life and business strategist. In this book, he teams up with Peter Mallouk, the only man in history to be ranked the #1 financial advisor in the US for three consecutive years by Barron\\'s. Together they reveal how to become unshakeable-someone who can not only maintain true peace of mind in a world of immense uncertainty, economic volatility, and unprecedented change, but who can profit from the fear that immobilizes so many.",
                Author = userTony,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "43.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFinanceBusiness,
                    categoryChildrenPersonalImprovement
                }
            };

            Context.Books.Add(book43);

            var book44 = new Book
            {
                Title = "The Path: Accelerating Your Journey to Financial Freeedom",
                PageCount = 316,
                Price = 24.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 23.99m
                    },
                    new Price
                    {
                        Value = 24.99m
                    }
                },
                ReleaseDate = new DateTime(2020, 4, 13),
                Description = "Accelerate your journey to financial freedom with the tools, strategies, and mindset of money mastery.\r\n\r\nRegardless of your stage of life and your current financial picture, the quest for financial freedom can indeed be conquered. The journey will demand the right tools and strategies along with the mindset of money mastery. With decades of collective wisdom and hands-on experience, your guides for this expedition are Peter Mallouk, the only man in history to be ranked the #1 Financial Advisor in the U.S. for three consecutive years by Barron\\'s (2013, 2014, 2015), and Tony Robbins, the world-renowned life and business strategist. Mallouk and Robbins take the seemingly daunting goal of financial freedom and simplify it into a step-by-step process that anyone can achieve.",
                Author = userTony,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "44.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenPersonalImprovement,
                    categoryChildrenFinanceBusiness
                }
            };

            Context.Books.Add(book44);

            var book45 = new Book
            {
                Title = "The Emotion Code",
                PageCount = 349,
                Price = 64.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 62.99m
                    },
                    new Price
                    {
                        Value = 64.99m
                    }
                },
                ReleaseDate = new DateTime(2022, 2, 15),
                Description = "\"I believe that the discoveries in this book can change our understanding of how we store emotional experiences and in so doing, change our lives. The Emotion Code has already changed many lives around the world, and it is my hope that millions more will be led to use this simple tool to heal themselves and their loved ones.\"-Tony Robbins\r\n\r\nIn this newly revised and expanded edition of The Emotion Code, renowned holistic physician and lecturer Dr. Bradley Nelson skillfully lays bare the inner workings of the subconscious mind. He reveals how emotionally-charged events from your past can still be haunting you in the form of \\\\\"trapped emotions\\\\\"-emotional energies that literally inhabit your body. These trapped emotions can fester in your life and body, creating pain, malfunction, and eventual disease. They can also extract a heavy mental and emotional toll on you, impacting how you think, the choices that you make, and the level of success and abundance you are able to achieve. Perhaps most damaging of all, trapped emotional energies can gather around your heart, cutting off your ability to give and receive love.\r\n\r\nThe Emotion Code is a powerful and simple way to rid yourself of this unseen baggage. Dr. Nelson\\'s method gives you the tools to identify and release the trapped emotions in your life, eliminating your \"emotional baggage,\" and opening your heart and body to the positive energies of the world. Filled with real-world examples from many years of clinical practice, The Emotion Code is a distinct and authoritative work that has become a classic on self-healing.",
                Author = userTony,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "45.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenPersonalImprovement
                }
            };

            Context.Books.Add(book45);

            var book46 = new Book
            {
                Title = "Mastering the Art of French Cooking",
                PageCount = 754,
                Price = 55.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 53.99m
                    },
                    new Price
                    {
                        Value = 55.00m
                    }
                },
                ReleaseDate = new DateTime(2011, 9, 5),
                Description = "\"What a cookbook should be: packed with sumptuous recipes, detailed instructions, and precise line drawings. Some of the instructions look daunting, but as Child herself says in the introduction, \\'If you can read, you can cook.\\'\" -Entertainment Weekly\r\n\r\n\"I only wish that I had written it myself.\" -James Beard\r\n\r\nFeaturing 524 delicious recipes and over 100 instructive illustrations to guide readers every step of the way, Mastering the Art of French Cooking offers something for everyone, from seasoned experts to beginners who love good food and long to reproduce the savory delights of French cuisine.",
                Author = userJulia,
                Publisher = publisherKnopf,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "46.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenEthnicCooking
                }
            };

            Context.Books.Add(book46);

            var book47 = new Book
            {
                Title = "Mastering the Art of French Cooking, Volume 2",
                PageCount = 1244,
                Price = 45.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 42.99m
                    },
                    new Price
                    {
                        Value = 45.00m
                    }
                },
                ReleaseDate = new DateTime(2012, 12, 31),
                Description = "The beloved sequel to the bestselling classic, Mastering the Art of French Cooking, Volume II presents more fantastic step-by-step French recipes for home cooks.\r\n\r\nWorking from the principle that \"mastering any art is a continuing process,\" Julia Child and Simone Beck gathered together a brilliant selection of new dishes to bring you to a yet higher level of culinary mastery.\r\n\r\nThey have searched out more of the classic dishes and regional specialties of France, and adapted them so that Americans, working with American ingredients, in American kitchens, can achieve the incomparable flavors and aromas that bring up a rush of memories-of lunch at a country inn in Provence, of an evening at a great Paris restaurant, of the essential cooking of France.ext",
                Author = userJulia,
                Publisher = publisherKnopf,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "47.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenEthnicCooking
                }
            };

            Context.Books.Add(book47);

            var book48 = new Book
            {
                Title = "The French Chef Cookbook",
                PageCount = 1343,
                Price = 19.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 19.99m
                    }
                },
                ReleaseDate = new DateTime(2022, 2, 4),
                Description = "The beloved icon and author of best-selling classic Mastering the Art of French Cooking presents an array of delectable French recipes that first made her a household name.\r\n\r\nOriginally debuted on her first public television show, here are 119 traditional French recipes, tested and perfected for home cooks to enjoy-from Mayonnaise to Bouillabaisse, crepes to steaks, and delicious vegetables to delectable desserts. America\\'s first lady of food continues to profoundly shaped the way we cook, the way we eat, and the way we see food.",
                Author = userJulia,
                Publisher = publisherKnopf,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "48.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenEthnicCooking
                }
            };

            Context.Books.Add(book48);

            var book49 = new Book
            {
                Title = "Julia\'s Kitchen Wisdom",
                PageCount = 6544,
                Price = 45.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 42.99m
                    },
                    new Price
                    {
                        Value = 45.00m
                    }
                },
                ReleaseDate = new DateTime(2010, 2, 3),
                Description = "In this indispensable volume of kitchen wisdom, Julia Child gives home cooks the answers to their most pressing cooking questions-with essential information about soups, vegetables, eggs, baking breads and tarts, and more.\r\n\r\nHow many minutes should you cook green beans? What are the right proportions for a vinaigrette? How do you skim off fat? What is the perfect way to roast a chicken?\r\n\r\nHere Julia provides solutions for these and many other everyday cooking queries. How are you going to cook that small rib steak you brought home? You\\'ll be guided to the quick sauté as the best and fastest way. And once you\\'ve mastered that recipe, you can apply the technique to chops, chicken, or fish, following Julia\\'s careful guidelines.",
                Author = userJulia,
                Publisher = publisherKnopf,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "49.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenEthnicCooking,
                    categoryChildrenHealthyCooking
                }
            };

            Context.Books.Add(book49);

            var book50 = new Book
            {
                Title = "People Who Love to Eat Are Always the Best People",
                PageCount = 91,
                Price = 62.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 60.99m
                    },
                    new Price
                    {
                        Value = 62.99m
                    }
                },
                ReleaseDate = new DateTime(2020, 4, 6),
                Description = "Perfect for home cooks, Julia fans, and anyone who simply loves to eat and drink-a delightful collection of the beloved chef and bestselling author\\'s words of wisdom on love, life, and, of course, food.\r\n\r\n\"If you\\'re afraid of butter, use cream.\\\\\" So decrees Julia Child, the legendary culinary authority and cookbook author who taught America how to cook-and how to eat. This delightful volume of quotations compiles some of Julia\\'s most memorable lines on eating-\"The only time to eat diet food is while you\\'re waiting for the steak to cook\"-on drinking, on life-\"I think every woman should have a blowtorch\"-on love, travel, France, and much more.",
                Author = userJulia,
                Publisher = publisherKnopf,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "50.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHealthyCooking
                }
            };

            Context.Books.Add(book50);

            var book51 = new Book
            {
                Title = "The Way to Cook",
                PageCount = 528,
                Price = 77.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 72.99m
                    },
                    new Price
                    {
                        Value = 77.99m
                    }
                },
                ReleaseDate = new DateTime(1989, 1, 31),
                Description = "In her most creative and instructive cookbook, Julia Child distills a lifetime of cooking into 800 recipes emphasizing lightness, freshness, and simplicity. Chapters are structured around master recipes, followed by innumerable variations that are easily made once the basics are understood. For example, make Julia\\'s simple but impeccably prepared sauté of chicken, and before long you\\'re easily whipping up Chicken with Mushrooms and Cream, Chicken Provençale, Chicken Pipérade, or Chicken Marengo. Or master her perfect broiled butterflied chicken, and you\\'ll soon be including Deviled Rabbit or Split Cornish Game Hens Broiled with Cheese on your menu.\r\n\r\nHere home cooks will find a treasure trove of poultry and fish recipes, as well as a vast array of fresh vegetables prepared in new ways, along with bread doughs and delicious indulgences, such as Caramel Apple Mountain or a Queen of Sheba Chocolate Almond Cake with Chocolate Leaves. And if you want to know how a finished dish should look or how to angle your knife or to fashion a pretty rosette on a cake, there are more than 600 color photographs to entice and instruct you along the way. A brilliant, inspiring, one-of-a-kind, book from the incomparable Julia Child, The Way to Cook is a testament to the satisfactions of good home cooking.",
                Author = userJulia,
                Publisher = publisherKnopf,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "51.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHealthyCooking
                }
            };

            Context.Books.Add(book51);

            var book52 = new Book
            {
                Title = "Julia and Jacques Cooking at Home",
                PageCount = 448,
                Price = 43.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 41.99m
                    },
                    new Price
                    {
                        Value = 43.00m
                    }
                },
                ReleaseDate = new DateTime(1999, 3, 6),
                Description = "Two legendary cooks invite us into their kitchen and show us the basics of good home cooking.\r\n\r\nJulia Child and Jacques Pépin are synonymous with good food, and in these pages they demonstrate techniques (on which they don\\'t always agree), discuss ingredients, improvise, balance flavors to round out a meal, and conjure up new dishes from leftovers. Center stage are carefully spelled-out recipes flanked by Julia\\'s and Jacques\\'s comments-the accumulated wisdom of two lifetimes of honing their cooking skills. Nothing is written in stone, they imply. And that is one of the most important lessons for every good cook.",
                Author = userJulia,
                Publisher = publisherKnopf,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "52.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHealthyCooking
                }
            };

            Context.Books.Add(book52);

            var book53 = new Book
            {
                Title = "My Life in France",
                PageCount = 336,
                Price = 32.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 30.99m
                    },
                    new Price
                    {
                        Value = 32.00m
                    }
                },
                ReleaseDate = new DateTime(2006, 9, 3),
                Description = "Julia\\'s story of her transformative years in France in her own words is \"captivating ... her marvelously distinctive voice is present on every page.\" (San Francisco Chronicle).\r\n\r\nAlthough she would later singlehandedly create a new approach to American cuisine with her cookbook Mastering the Art of French Cooking and her television show The French Chef, Julia Child was not always a master chef. Indeed, when she first arrived in France in 1948 with her husband, Paul, who was to work for the USIS, she spoke no French and knew nothing about the country itself.",
                Author = userJulia,
                Publisher = publisherKnopf,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "53.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalTravel
                }
            };

            Context.Books.Add(book53);

            var book54 = new Book
            {
                Title = "Baking with Julia",
                PageCount = 512,
                Price = 15.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 11.99m
                    },
                    new Price
                    {
                        Value = 15.99m
                    }
                },
                ReleaseDate = new DateTime(1996, 4, 27),
                Description = "Nothing promises pleasure more readily than the words \"freshly baked.\" And nothing says magnum opus as definitively as Baking with Julia, which offers the dedicated home cook, whether a novice or seasoned veteran, a unique distillation of the baker\\'s art.\r\n\r\nBaking with Julia is not only a book full of glorious recipes but also one that continues Julia\\'s teaching tradition. Here, basic techniques come alive and are made easily comprehensible in recipes that demonstrate the myriad ways of raising dough, glazing cakes, and decorating crusts. This is the resource you\\'ll turn to again and again for all your baking needs. With Baking with Julia in your cookbook library, you can become a master baker.",
                Author = userJulia,
                Publisher = publisherKnopf,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "54.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHealthyCooking
                }
            };

            Context.Books.Add(book54);

            var book55 = new Book
            {
                Title = "Julia\'s Breakfasts, Lunches, and Suppers: Seven me",
                PageCount = 113,
                Price = 45.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 42.99m
                    },
                    new Price
                    {
                        Value = 45.00m
                    }
                },
                ReleaseDate = new DateTime(1990, 4, 25),
                Description = "Here are seven menus to make any meal a treat--morning, noon, or evening. From a breezy Holiday Lunch featuring a melon-sized pate of chicken and a salad of skewered vegetables to a homey Sunday Night Supper of corned beef and pork with a fresh tomato fondue, Julia shows you how to plan ahead and cook without trepidation. Her incomparable step-by-step recipes, shopping lists, variations, and suggestions for leftovers are complemented by more than 100 photographs and ensure success with every meal.",
                Author = userJulia,
                Publisher = publisherKnopf,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "55.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHealthyCooking
                }
            };

            Context.Books.Add(book55);

            var book56 = new Book
            {
                Title = "One: Simple One-Pan Wonders",
                PageCount = 312,
                Price = 21.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 20.99m
                    },
                    new Price
                    {
                        Value = 21.99m
                    }
                },
                ReleaseDate = new DateTime(2023, 1, 1),
                Description = "One is the ultimate cookbook that will make getting good food on the table easier than ever before . . . Jamie Oliver is back to basics with over 120 simple, delicious, ONE pan recipes.\r\n\r\nIn ONE, Jamie Oliver will guide you through over 120 recipes for tasty, fuss-free and satisfying dishes cooked in just one pan. What\\'s better: each recipe has just eight ingredients or fewer, meaning minimal prep (and cleaning up) and offering maximum convenience.\r\n\r\nPacked with budget-friendly dishes you can rustle up any time, ONE has everything from delicious work from home lunches to quick dinners the whole family will love; from meat-free options to meals that will get novice cooks started.",
                Author = userJamie,
                Publisher = publisherFlatiron,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "56.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHealthyCooking
                }
            };

            Context.Books.Add(book56);

            var book57 = new Book
            {
                Title = "5 Ingredients: Quick & Easy Food",
                PageCount = 490,
                Price = 54.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 51.99m
                    },
                    new Price
                    {
                        Value = 54.99m
                    }
                },
                ReleaseDate = new DateTime(2019, 1, 8),
                Description = "Jamie Oliver--one of the bestselling cookbook authors of all time--is back with a bang. Focusing on incredible combinations of just five ingredients, he\'s created 130 brand-new recipes that you can cook up at home, any day of the week. From salads, pasta, chicken, and fish to exciting ways with vegetables, rice and noodles, beef, pork, and lamb, plus a bonus chapter of sweet treats, Jamie\'s got all the bases covered. This is about maximum flavor with minimum fuss, lots of nutritious options, and loads of epic inspiration.",
                Author = userJamie,
                Publisher = publisherFlatiron,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "57.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHealthyCooking
                }
            };

            Context.Books.Add(book57);

            var book58 = new Book
            {
                Title = "Jamie\'s 30-Minute Meals",
                PageCount = 408,
                Price = 55.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 50.99m
                    },
                    new Price
                    {
                        Value = 55.00m
                    }
                },
                ReleaseDate = new DateTime(2017, 5, 4),
                Description = "Jamie Oliver will teach you how to make good food super-fast in his game-changing guide to coordinating an entire meal without any fuss.\r\n\r\nWith 50 exciting, seasonal meal ideas, Jamie\\'s 30 Minute Meals provides the essential collection of dishes for putting on the ultimate three-course meal without taking up your time.\r\n\r\nNot only that, Jamie also includes refreshing, light lunch recipes that you can put together in no time at all.",
                Author = userJamie,
                Publisher = publisherFlatiron,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "58.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHealthyCooking
                }
            };

            Context.Books.Add(book58);

            var book59 = new Book
            {
                Title = "Together: Memorable Meals Made Easy",
                PageCount = 350,
                Price = 64.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 60.99m
                    },
                    new Price
                    {
                        Value = 64.99m
                    }
                },
                ReleaseDate = new DateTime(2021, 1, 9),
                Description = "Welcome friends and family back around your table with Jamie Oliver\\'s brand-new cookbook, Together - a joyous celebration of incredible food to share.\r\n\r\nBeing with our loved ones has never felt so important, and great food is the perfect excuse to get together. Each chapter features a meal, from seasonal feasts to curry nights, with a simple, achievable menu that can be mostly prepped ahead.\r\n\r\nJamie\\'s aim - whether you\\'re following the full meal or choosing just one of the 130 individual recipes - is to minimize your time in the kitchen so you can maximize the time you spend with your guests.",
                Author = userJamie,
                Publisher = publisherFlatiron,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "59.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHealthyCooking
                }
            };

            Context.Books.Add(book59);

            var book60 = new Book
            {
                Title = "Ultimate Veg",
                PageCount = 468,
                Price = 21.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 17.99m
                    },
                    new Price
                    {
                        Value = 21.99m
                    }
                },
                ReleaseDate = new DateTime(2020, 5, 5),
                Description = "Jamie Oliver, one of the bestselling cookbook authors of all time, is back with brilliantly easy, delicious, and flavor-packed vegetable recipes.\r\n\r\nThis edition has been adapted for the US market. It was originally published in the UK under the title Veg.\r\n\r\nFrom simple suppers and family favorites, to weekend dishes for sharing with friends, this book is packed full of phenomenal food - pure and simple.",
                Author = userJamie,
                Publisher = publisherFlatiron,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "60.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHealthyCooking
                }
            };

            Context.Books.Add(book60);

            var book61 = new Book
            {
                Title = "Hackers",
                PageCount = 654,
                Price = 35.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 32.99m
                    },
                    new Price
                    {
                        Value = 35.00m
                    }
                },
                ReleaseDate = new DateTime(2010, 4, 5),
                Description = "This 25th anniversary edition of Steven Levy\\'s classic book traces the exploits of the computer revolution\\'s original hackers -- those brilliant and eccentric nerds from the late 1950s through the early \\'80s who took risks, bent the rules, and pushed the world in a radical new direction. With updated material from noteworthy hackers such as Bill Gates, Mark Zuckerberg, Richard Stallman, and Steve Wozniak, Hackers is a fascinating story that begins in early computer research labs and leads to the first home computers.\r\n\r\nLevy profiles the imaginative brainiacs who found clever and unorthodox solutions to computer engineering problems. They had a shared sense of values, known as \"the hacker ethic,\" that still thrives today. Hackers captures a seminal period in recent history when underground activities blazed a trail for today\\'s digital world, from MIT students finagling access to clunky computer-card machines to the DIY culture that spawned the Altair and the Apple II.",
                Author = userSteven,
                Publisher = publisherOreilly,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "61.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCybersecurityTechnology
                }
            };

            Context.Books.Add(book61);

            var book62 = new Book
            {
                Title = "In the Plex",
                PageCount = 461,
                Price = 53.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 50.99m
                    },
                    new Price
                    {
                        Value = 53.00m
                    }
                },
                ReleaseDate = new DateTime(2011, 12, 8),
                Description = "\"The most interesting book ever written about Google\" (The Washington Post) delivers the inside story behind the most successful and admired technology company of our time, now updated with a new Afterword.\r\n\r\nGoogle is arguably the most important company in the world today, with such pervasive influence that its name is a verb. The company founded by two Stanford graduate students-Larry Page and Sergey Brin-has become a tech giant known the world over. Since starting with its search engine, Google has moved into mobile phones, computer operating systems, power utilities, self-driving cars, all while remaining the most powerful company in the advertising business.\r\n\r\nGranted unprecedented access to the company, Levy disclosed that the key to Google\\'s success in all these businesses lay in its engineering mindset and adoption of certain internet values such as speed, openness, experimentation, and risk-taking. Levy discloses details behind Google\\'s relationship with China, including how Brin disagreed with his colleagues on the China strategy-and why its social networking initiative failed; the first time Google tried chasing a successful competitor. He examines Google\\'s rocky relationship with government regulators, particularly in the EU, and how it has responded when employees left the company for smaller, nimbler start-ups.",
                Author = userSteven,
                Publisher = publisherOreilly,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "62.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenComputerTechnology
                }
            };

            Context.Books.Add(book62);

            var book63 = new Book
            {
                Title = "Crypto",
                PageCount = 370,
                Price = 32.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 30.99m
                    },
                    new Price
                    {
                        Value = 32.99m
                    }
                },
                ReleaseDate = new DateTime(2001, 7, 3),
                Description = "If you\\'ve ever made a secure purchase with your credit card over the Internet, then you have seen cryptography, or \"crypto\", in action. From Stephen Levy-the author who made \"hackers\" a household word-comes this account of a revolution that is already affecting every citizen in the twenty-first century. Crypto tells the inside story of how a group of \"crypto rebels\"-nerds and visionaries turned freedom fighters-teamed up with corporate interests to beat Big Brother and ensure our privacy on the Internet. Levy\\'s history of one of the most controversial and important topics of the digital age reads like the best futuristic fiction.",
                Author = userSteven,
                Publisher = publisherOreilly,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "63.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenComputerTechnology
                }
            };

            Context.Books.Add(book63);

            var book64 = new Book
            {
                Title = "Facebook: The Inside Story",
                PageCount = 592,
                Price = 43.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 41.99m
                    },
                    new Price
                    {
                        Value = 43.00m
                    }
                },
                ReleaseDate = new DateTime(2020, 9, 6),
                Description = "One of the Best Technology Books of 2020-Financial Times\r\n\r\n\"Levy\\'s all-access Facebook reflects the reputational swan dive of its subject. . . . The result is evenhanded and devastating.\"-San Francisco Chronicle\r\n\r\nThe definitive history, packed with untold stories, of one of America\\'s most controversial and powerful companies: Facebook",
                Author = userSteven,
                Publisher = publisherOreilly,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "64.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenComputerTechnology
                }
            };

            Context.Books.Add(book64);

            var book65 = new Book
            {
                Title = "Insanely Great",
                PageCount = 338,
                Price = 65.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 61.99m
                    },
                    new Price
                    {
                        Value = 65.00m
                    }
                },
                ReleaseDate = new DateTime(2012, 3, 4),
                Description = "The creation of the Mac in 1984 catapulted America into the digital millennium, captured a fanatic cult audience, and transformed the computer industry into an unprecedented mix of technology, economics, and show business. Now veteran technology writer and Newsweek senior editor Steven Levy zooms in on the great machine and the fortunes of the unique company responsible for its evolution. Loaded with anecdote and insight, and peppered with sharp commentary, Insanely Great is the definitive book on the most important computer ever made. It is a must-have for anyone curious about how we got to the interactive age.\r\n\r\nThis new edition includes a never-before-seen transcript of an interview with Steve Jobs.",
                Author = userSteven,
                Publisher = publisherOreilly,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "65.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenComputerTechnology
                }
            };

            Context.Books.Add(book65);

            var book66 = new Book
            {
                Title = "The Code Breaker",
                PageCount = 552,
                Price = 64.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 62.99m
                    },
                    new Price
                    {
                        Value = 64.99m
                    }
                },
                ReleaseDate = new DateTime(2020, 2, 1),
                Description = "The bestselling author of Leonardo da Vinci and Steve Jobs returns with a \"compelling\" (The Washington Post) account of how Nobel Prize winner Jennifer Doudna and her colleagues launched a revolution that will allow us to cure diseases, fend off viruses, and have healthier babies.\r\n\r\nWhen Jennifer Doudna was in sixth grade, she came home one day to find that her dad had left a paperback titled The Double Helix on her bed. She put it aside, thinking it was one of those detective tales she loved. When she read it on a rainy Saturday, she discovered she was right, in a way. As she sped through the pages, she became enthralled by the intense drama behind the competition to discover the code of life. Even though her high school counselor told her girls didn\\'t become scientists, she decided she would.\r\n\r\nDriven by a passion to understand how nature works and to turn discoveries into inventions, she would help to make what the book\\'s author, James Watson, told her was the most important biological advance since his codiscovery of the structure of DNA. She and her collaborators turned a curiosity of nature into an invention that will transform the human race: an easy-to-use tool that can edit DNA. Known as CRISPR, it opened a brave new world of medical miracles and moral questions.",
                Author = userWalter,
                Publisher = publisherOreilly,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "66.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenComputerTechnology,
                    categoryChildrenCybersecurityTechnology
                }
            };

            Context.Books.Add(book66);

            var book67 = new Book
            {
                Title = "The Wise Men: Six Friends and the World They Made",
                PageCount = 873,
                Price = 45.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 41.99m
                    },
                    new Price
                    {
                        Value = 45.00m
                    }
                },
                ReleaseDate = new DateTime(2012, 3, 12),
                Description = "With a new introduction by the authors, this is the classic account of the American statesmen who rebuilt the world after the catastrophe of World War II.\r\n\r\nA captivating blend of personal biography and public drama, The Wise Men introduces six close friends who shaped the role their country would play in the dangerous years following World War II.\r\n\r\nThey were the original best and brightest, whose towering intellects, outsize personalities, and dramatic actions would bring order to the postwar chaos and leave a legacy that dominates American policy to this day.",
                Author = userWalter,
                Publisher = publisherOreilly,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "67.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenComputerTechnology
                }
            };

            Context.Books.Add(book67);

            var book68 = new Book
            {
                Title = "The Innovators",
                PageCount = 560,
                Price = 34.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 31.99m
                    },
                    new Price
                    {
                        Value = 34.99m
                    }
                },
                ReleaseDate = new DateTime(2014, 2, 9),
                Description = "Following his blockbuster biography of Steve Jobs, Walter Isaacson\\'s New York Times bestselling and critically acclaimed The Innovators is a \"riveting, propulsive, and at times deeply moving\" (The Atlantic) story of the people who created the computer and the internet.\r\n\r\nWhat were the talents that allowed certain inventors and entrepreneurs to turn their visionary ideas into disruptive realities? What led to their creative leaps? Why did some succeed and others fail?\r\n\r\nThe Innovators is a masterly saga of collaborative genius destined to be the standard history of the digital revolution-and an indispensable guide to how innovation really happens. Isaacson begins the adventure with Ada Lovelace, Lord Byron\\'s daughter, who pioneered computer programming in the 1840s. He explores the fascinating personalities that created our current digital revolution, such as Vannevar Bush, Alan Turing, John von Neumann, J.C.R. Licklider, Doug Engelbart, Robert Noyce, Bill Gates, Steve Wozniak, Steve Jobs, Tim Berners-Lee, and Larry Page.",
                Author = userWalter,
                Publisher = publisherOreilly,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "68.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenComputerTechnology
                }
            };

            Context.Books.Add(book68);

            var book69 = new Book
            {
                Title = "Leonardo da Vinci",
                PageCount = 625,
                Price = 53.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 51.99m
                    },
                    new Price
                    {
                        Value = 53.00m
                    }
                },
                ReleaseDate = new DateTime(2017, 4, 12),
                Description = "The #1 New York Times bestseller from Walter Isaacson brings Leonardo da Vinci to life in this exciting new biography that is \"a study in creativity: how to define it, how to achieve it…Most important, it is a powerful story of an exhilarating mind and life\" (The New Yorker).\r\n\r\nBased on thousands of pages from Leonardo da Vinci\\'s astonishing notebooks and new discoveries about his life and work, Walter Isaacson \"deftly reveals an intimate Leonardo\" (San Francisco Chronicle) in a narrative that connects his art to his science. He shows how Leonardo\\'s genius was based on skills we can improve in ourselves, such as passionate curiosity, careful observation, and an imagination so playful that it flirted with fantasy.\r\n\r\nHe produced the two most famous paintings in history, The Last Supper and the Mona Lisa. With a passion that sometimes became obsessive, he pursued innovative studies of anatomy, fossils, birds, the heart, flying machines, botany, geology, and weaponry. He explored the math of optics, showed how light rays strike the cornea, and produced illusions of changing perspectives in The Last Supper. His ability to stand at the crossroads of the humanities and the sciences, made iconic by his drawing of Vitruvian Man, made him history\\'s most creative genius.",
                Author = userWalter,
                Publisher = publisherOreilly,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "69.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenComputerTechnology,
                    categoryChildrenSocialHistory
                }
            };

            Context.Books.Add(book69); 
            
            var book70 = new Book
            {
                Title = "Einstein: His Life and Universe",
                PageCount = 710,
                Price = 34.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 31.99m
                    },
                    new Price
                    {
                        Value = 34.99m
                    }
                },
                ReleaseDate = new DateTime(2022, 6, 16),
                Description = "By the author of the acclaimed bestsellers Benjamin Franklin and Steve Jobs, this is the definitive biography of Albert Einstein.\r\n\r\nHow did his mind work? What made him a genius? Isaacson\\'s biography shows how his scientific imagination sprang from the rebellious nature of his personality. His fascinating story is a testament to the connection between creativity and freedom.\r\n\r\nBased on newly released personal letters of Einstein, this book explores how an imaginative, impertinent patent clerk-a struggling father in a difficult marriage who couldn\\'t get a teaching job or a doctorate-became the mind reader of the creator of the cosmos, the locksmith of the mysteries of the atom, and the universe. His success came from questioning conventional wisdom and marveling at mysteries that struck others as mundane. This led him to embrace a morality and politics based on respect for free minds, free spirits, and free individuals.",
                Author = userWalter,
                Publisher = publisherOreilly,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "70.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenSocialHistory,
                    categoryChildrenComputerTechnology
                }
            };

            Context.Books.Add(book70);

            var book71 = new Book
            {
                Title = "Green Eggs and Ham",
                PageCount = 65,
                Price = 66.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 63.99m
                    },
                    new Price
                    {
                        Value = 66.99m
                    }
                },
                ReleaseDate = new DateTime(2013, 8, 2),
                Description = "Join in the fun with Sam-I-Am in this iconic classic by Dr. Seuss that will have readers of all ages craving Green Eggs and Ham! This is a beloved classic from the bestselling author of Horton Hears a Who!, The Lorax, and Oh, the Places You\\'ll Go!\r\n\r\nWith unmistakable characters and signature rhymes, Dr. Seuss\\'s beloved favorite has cemented its place as a children\\'s classic. Kids will love the terrific tongue-twisters as the list of places to enjoy green eggs and ham gets longer and longer...and they might even learn a thing or two about trying new things!\r\n\r\nAnd don\\'t miss the Netflix series adaptation!",
                Author = userTheodor,
                Publisher = publisherYoungReaders,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "70.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenStoriesChildren,
                    categoryChildrenFictionChildren
                }
            };

            Context.Books.Add(book71);

            var book72 = new Book
            {
                Title = "Oh, the Places You\'ll Go!",
                PageCount = 56,
                Price = 45.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 41.99m
                    },
                    new Price
                    {
                        Value = 45.00m
                    }
                },
                ReleaseDate = new DateTime(2013, 1, 3),
                Description = "Dr. Seuss\\'s wonderfully wise Oh, the Places You\\'ll Go! is the perfect gift to celebrate all of our special milestones-from graduations to birthdays and beyond!\r\n\r\nFrom soaring to high heights and seeing great sights to being left in a Lurch on a prickle-ly perch, Dr. Seuss addresses life\\'s ups and downs with his trademark humorous verse and whimsical illustrations.\r\n\r\nThe inspiring and timeless message encourages readers to find the success that lies within, no matter what challenges they face. A perennial favorite and a perfect gift for anyone starting a new phase in their life!",
                Author = userTheodor,
                Publisher = publisherYoungReaders,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "72.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenStoriesChildren
                }
            };

            Context.Books.Add(book72);

            var book73 = new Book
            {
                Title = "One Fish Two Fish Red Fish Blue Fish",
                PageCount = 67,
                Price = 23.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 21.99m
                    },
                    new Price
                    {
                        Value = 23.00m
                    }
                },
                ReleaseDate = new DateTime(2013, 9, 8),
                Description = "Count and explore the zany world and words of Seuss in this classic picture book.\r\n\r\nFrom counting to opposites to Dr. Seuss\\'s signature silly rhymes, this book has everything a beginning reader needs! Meet the bumpy Wump and the singing Ying, and even the winking Yink who drinks pink ink. The silly rhymes and colorful cast of characters will have every child giggling from morning to night.\r\n\r\nOriginally created by Dr. Seuss himself, Beginner Books are fun, funny, and easy to read. These unjacketed hardcover early readers encourage children to read all on their own, using simple words and illustrations. Smaller than the classic large format Seuss picture books like The Lorax and Oh, the Places You\\'ll Go!, these portable packages are perfect for practicing readers ages 3-7, and lucky parents too!",
                Author = userTheodor,
                Publisher = publisherYoungReaders,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "73.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFictionChildren
                }
            };

            Context.Books.Add(book73);

            var book74 = new Book
            {
                Title = "The Cat in the Hat",
                PageCount = 345,
                Price = 14.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 9.99m
                    },
                    new Price
                    {
                        Value = 14.00m
                    }
                },
                ReleaseDate = new DateTime(2013, 9, 2),
                Description = "Have a ball with Dr. Seuss and the Cat in the Hat in this classic picture book...but don\\'t forget to clean up your mess!\r\n\r\nA dreary day turns into a wild romp when this beloved story introduces readers to the Cat in the Hat and his troublemaking friends, Thing 1 and Thing 2. A favorite among kids, parents and teachers, this story uses simple words and basic ryhme to encourage and delight beginning readers.\r\n\r\nOriginally created by Dr. Seuss himself, Beginner Books are fun, funny, and easy to read. These unjacketed hardcover early readers encourage children to read all on their own, using simple words and illustrations. Smaller than the classic large format Seuss picture books like The Lorax and Oh, The Places You\\'ll Go!, these portable packages are perfect for practicing readers ages 3-7, and lucky parents too!",
                Author = userTheodor,
                Publisher = publisherYoungReaders,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "74.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFictionChildren,
                    categoryChildrenStoriesChildren
                }
            };

            Context.Books.Add(book74);

            var book75 = new Book
            {
                Title = "How the Grinch Stole Christmas",
                PageCount = 64,
                Price = 12.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 10.99m
                    },
                    new Price
                    {
                        Value = 12.99m
                    }
                },
                ReleaseDate = new DateTime(2013, 2, 12),
                Description = "Grow your heart three sizes and get in on all of the Grinch-mas cheer with this Christmas classic--the ultimate Dr. Seuss holiday book that no collection is complete without!\r\n\r\nEvery Who down in Who-ville liked Christmas a lot . . . but the Grinch, who lived just north of Who-ville, did NOT!\r\n\r\nNot since \"\\'Twas the night before Christmas\" has the beginning of a Christmas tale been so instantly recognizable. This heartwarming story about the effects of the Christmas spirit will grow even the coldest and smallest of hearts. Like mistletoe, candy canes, and caroling, the Grinch is a mainstay of the holidays, and his story is the perfect gift for readers young and old.",
                Author = userTheodor,
                Publisher = publisherYoungReaders,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "75.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenStoriesChildren,
                    categoryChildrenFictionChildren
                }
            };

            Context.Books.Add(book75);

            var book76 = new Book
            {
                Title = "Fox in Socks",
                PageCount = 62,
                Price = 13.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 11.99m
                    },
                    new Price
                    {
                        Value = 13.99m
                    }
                },
                ReleaseDate = new DateTime(2013, 7, 17),
                Description = "Find out how wacky words can be with Dr. Seuss and the Fox in Socks in this classic hardcover picture book of tongue tanglers!\r\n\r\nThis rhyming romp includes chicks with bricks, chewy blue glue, a noodle eating poodle, and so much more! Just try to keep your tongue out of trouble! Seuss piles his the energetic rhymes into a mountain of hilarity that the whole family will enjoy. Rhyming has never been this fun!\r\n\r\nOriginally created by Dr. Seuss himself, Beginner Books are fun, funny, and easy to read. These unjacketed hardcover early readers encourage children to read all on their own, using simple words and illustrations. Smaller than the classic large format Seuss picture books like The Lorax and Oh, The Places You\\'ll Go!, these portable packages are perfect for practicing readers ages 3-7, and lucky parents too!",
                Author = userTheodor,
                Publisher = publisherYoungReaders,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "76.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFictionChildren,
                    categoryChildrenStoriesChildren
                }
            };

            Context.Books.Add(book76);

            var book77 = new Book
            {
                Title = "The Sneetches and Other Stories",
                PageCount = 72,
                Price = 11.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 9.99m
                    },
                    new Price
                    {
                        Value = 11.99m
                    }
                },
                ReleaseDate = new DateTime(2013, 6, 25),
                Description = "An iconic collection of original stories from Dr. Seuss that includes the official versions of \"The Sneetches,\" \"The Zax,\" \"Too Many Daves,\" and \"What Was I Scared Of?\" This is a beloved classic that deserves a place in every child\\'s library-from the bestselling author of Horton Hears a Who!, The Lorax, and Oh, the Places You\\'ll Go!\r\n\r\nIn these four timeless stories, Dr. Seuss challenges the assumption that we need to look the same or behave the same to find common ground. Filled with Dr. Seuss\\'s signature rhymes and lively humor, this classic story collection is a must-have for readers of all ages, and is ideal for sparking discussions about tolerance, diversity, and acceptance.",
                Author = userTheodor,
                Publisher = publisherYoungReaders,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "77.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFictionChildren
                }
            };

            Context.Books.Add(book77);

            var book78 = new Book
            {
                Title = "The Lorax",
                PageCount = 72,
                Price = 14.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 11.99m
                    },
                    new Price
                    {
                        Value = 14.99m
                    }
                },
                ReleaseDate = new DateTime(2013, 2, 16),
                Description = "Celebrate Earth Day with Dr. Seuss and the Lorax in this classic picture book about protecting the environment!\r\n\r\nDr. Seuss\\'s beloved story teaches kids to speak up and stand up for those who can\\'t. With a recycling-friendly \"Go Green\" message, The Lorax allows young readers to experience the beauty of the Truffula Trees and the danger of taking our earth for granted, all in a story that is timely, playful and hopeful. The book\\'s final pages teach us that just one small seed, or one small child, can make a difference.\r\n\r\nPrinted on recycled paper, this book is the perfect gift for Earth Day and for any child-or child at heart-who is interested in recycling, advocacy and the environment, or just loves nature and playing outside.",
                Author = userTheodor,
                Publisher = publisherYoungReaders,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "78.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFictionChildren
                }
            };

            Context.Books.Add(book78);

            var book79 = new Book
            {
                Title = "Dr. Seuss\'s ABC",
                PageCount = 63,
                Price = 14.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 11.99m
                    },
                    new Price
                    {
                        Value = 14.99m
                    }
                },
                ReleaseDate = new DateTime(2013, 3, 2),
                Description = "Arguably the most entertaining alphabet book ever written, this classic Beginner Book by Dr. Seuss is perfect for children learning their ABCs. Featuring a fantastic cast of zany characters-from Aunt Annie\\'s alligator to the Zizzer-Zazzer-Zuzz, with a lazy lion licking a lollipop and an ostrich oiling an orange owl-Dr. Seuss\\'s ABC is a must-have for every young child\\'s library.\r\n\r\nOriginally created by Dr. Seuss, Beginner Books encourage children to read all by themselves, with simple words and illustrations that give clues to their meaning.",
                Author = userTheodor,
                Publisher = publisherYoungReaders,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "79.jpg"
                },
                Categories = new List<Category>
                { categoryChildrenFictionChildren }
            };

            Context.Books.Add(book79);

            var book80 = new Book
            {
                Title = "Hop on Pop",
                PageCount = 75,
                Price = 9.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 6.99m
                    },
                    new Price
                    {
                        Value = 9.99m
                    }
                },
                ReleaseDate = new DateTime(2013, 5, 12),
                Description = "Join Dr. Seuss in this classic rhyming picture book-\"the simplest Seuss for youngest use.\"\r\n\r\nFull of short, simple words and silly rhymes, this book is perfect for reading alone or reading aloud with Dad!  The rollicking rythym will keep kids entertained on every page, and it\\'s an especially good way to  show Pop some love on Father\\'s Day!\r\n\r\nOriginally created by Dr. Seuss himself, Beginner Books are fun, funny, and easy to read. These unjacketed hardcover early readers encourage children to read all on their own, using simple words and illustrations. Smaller than the classic large format Seuss picture books like The Lorax and Oh, The Places You\\'ll Go!, these portable packages are perfect for practicing readers ages 3-7, and lucky parents too!",
                Author = userTheodor,
                Publisher = publisherYoungReaders,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "80.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFictionChildren,
                    categoryChildrenStoriesChildren
                }
            };

            Context.Books.Add(book80);

            var book81 = new Book
            {
                Title = "Matilda",
                PageCount = 240,
                Price = 21.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 19.99m
                    },
                    new Price
                    {
                        Value = 21.00m
                    }
                },
                ReleaseDate = new DateTime(2007, 12, 3),
                Description = "Now a musical on broadway and streaming on Netflix!\r\n\r\nMatilda is a sweet, exceptional young girl, but her parents think she\\'s just a nuisance. She expects school to be different but there she has to face Miss Trunchbull, a menacing, kid-hating headmistress. When Matilda is attacked by the Trunchbull she suddenly discovers she has a remarkable power with which to fight back. It\\'ll take a superhuman genius to give Miss Trunchbull what she deserves and Matilda may be just the one to do it!\r\n\r\nHere is Roald Dahl\\'s original novel of a little girl with extraordinary powers. This much-loved story has recently been made into a wonderful new musical, adapted by Dennis Kelly with music and lyrics by Tim Minchin.",
                Author = userRoald,
                Publisher = publisherViking,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "81.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFictionChildren
                }
            };

            Context.Books.Add(book81);

            var book82 = new Book
            {
                Title = "Charlie and the Chocolate Factory",
                PageCount = 162,
                Price = 14.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 11.99m
                    },
                    new Price
                    {
                        Value = 14.99m
                    }
                },
                ReleaseDate = new DateTime(2011, 3, 26),
                Description = "Willy Wonka\\'s famous chocolate factory is opening at last!\r\n\r\nBut only five lucky children will be allowed inside. And the winners are: Augustus Gloop, an enormously fat boy whose hobby is eating; Veruca Salt, a spoiled-rotten brat whose parents are wrapped around her little finger; Violet Beauregarde, a dim-witted gum-chewer with the fastest jaws around; Mike Teavee, a toy pistol-toting gangster-in-training who is obsessed with television; and Charlie Bucket, Our Hero, a boy who is honest and kind, brave and true, and good and ready for the wildest time of his life!\r\n\r\n",
                Author = userRoald,
                Publisher = publisherViking,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "82.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFictionChildren,
                    categoryChildrenStoriesChildren
                }
            };

            Context.Books.Add(book82);

            var book83 = new Book
            {
                Title = "James and the Giant Peach",
                PageCount = 153,
                Price = 14.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 12.99m
                    },
                    new Price
                    {
                        Value = 14.99m
                    }
                },
                ReleaseDate = new DateTime(2007, 8, 24),
                Description = "From the World\\'s No. 1 Storyteller, James and the Giant Peach is a children\\'s classic that has captured young reader\\'s imaginations for generations.\r\n\r\nOne of TIME MAGAZINE\\'s 100 Best Fantasy Books of All Time\r\n\r\nAfter James Henry Trotter\\'s parents are tragically eaten by a rhinoceros, he goes to live with his two horrible aunts, Spiker and Sponge. Life there is no fun, until James accidentally drops some magic crystals by the old peach tree and strange things start to happen. The peach at the top of the tree begins to grow, and before long it\\'s as big as a house. Inside, James meets a bunch of oversized friends-Grasshopper, Centipede, Ladybug, and more. With a snip of the stem, the peach starts rolling away, and the great adventure begins!",
                Author = userRoald,
                Publisher = publisherViking,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "83.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFictionChildren
                }
            };

            Context.Books.Add(book83);

            var book84 = new Book
            {
                Title = "The BFG",
                PageCount = 208,
                Price = 16.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 16.99m
                    }
                },
                ReleaseDate = new DateTime(2007, 1, 21),
                Description = "Roald Dahl\\'s beloved novel hits the big screen in July 2016 in a major motion picture adaptation directed by Steven Spielberg from Amblin Entertainment and Walt Disney Pictures.\r\n\r\nWhen Sophie is snatched from her orphanage bed by the BFG (Big Friendly Giant), she fears she will be eaten. But instead the two join forces to vanquish the nine other far less gentle giants who threaten to consume earth\\'s children. This beautiful hardcover gift edition of Dahl\\'s classic features the original illustrations by Quentin Blake, as well as a silk ribbon marker, acid-free paper, gilt stamping on a full-cloth cover, decorative endpapers, and a sewn binding.",
                Author = userRoald,
                Publisher = publisherViking,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "84.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFictionChildren
                }
            };

            Context.Books.Add(book84);

            var book85 = new Book
            {
                Title = "Charlie and the Great Glass Elevator",
                PageCount = 165,
                Price = 13.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 10.99m
                    },
                    new Price
                    {
                        Value = 13.99m
                    }
                },
                ReleaseDate = new DateTime(2007, 6, 21),
                Description = "From the bestselling author of Charlie and the Chocolate Factory and The BFG!\r\n\r\nLast seen flying through the sky in a giant elevator in Charlie and the Chocolate Factory, Charlie Bucket\\'s back for another adventure. When the giant elevator picks up speed, Charlie, Willy Wonka, and the gang are sent hurtling through space and time. Visiting the world\\'\\' first space hotel, battling the dreaded Vermicious Knids, and saving the world are only a few stops along this remarkable, intergalactic joyride.",
                Author = userRoald,
                Publisher = publisherViking,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "85.jpg"
                },
                Categories = new List<Category>
                { categoryChildrenFictionChildren }
            };

            Context.Books.Add(book85);

            var book86 = new Book
            {
                Title = "Dreamland",
                PageCount = 359,
                Price = 16.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 16.99m
                    }
                },
                ReleaseDate = new DateTime(2022, 11, 4),
                Description = "#1 NEW YORK TIMES BESTSELLER • A twist you won\\'t see coming. A love story you\\'ll never forget. From the acclaimed author of The Notebook comes a powerful novel about risking everything for a dream-and whether it\\'s possible to leave the past behind.\r\n\r\nWe don\\'t always get to choose our paths in life; sometimes they choose us.\r\n\r\nAfter fleeing an abusive husband with her six-year-old son, Tommie, Beverly is attempting to create a new life for them in a small town off the beaten track. Despite their newfound freedom, Beverly is constantly on guard: she creates a fake backstory, wears a disguise around town, and buries herself in DIY projects to stave off anxiety. But her stress only rises when Tommie insists he\\'d been hearing someone walking on the roof and calling his name late at night. With money running out and danger seemingly around every corner, she makes a desperate decision that will rewrite everything she knows to be true. . . .",
                Author = userNicholas,
                Publisher = publisherHouse,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "86.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyRomance
                }
            };

            Context.Books.Add(book86);

            var book87 = new Book
            {
                Title = "The Wish",
                PageCount = 401,
                Price = 21.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 18.99m
                    },
                    new Price
                    {
                        Value = 21.00m
                    }
                },
                ReleaseDate = new DateTime(2021, 3, 17),
                Description = "With exclusive travel photos and a special letter from the Author, only available for e-readers.\r\n\r\nFrom the author of The Longest Ride and The Return comes a novel about the enduring legacy of first love, and the decisions that haunt us forever.\r\n\r\n1996 was the year that changed everything for Maggie Dawes. Sent away at sixteen to live with an aunt she barely knew in Ocracoke, a remote village on North Carolina\\'s Outer Banks, she could think only of the friends and family she left behind . . . until she met Bryce Trickett, one of the few teenagers on the island. Handsome, genuine, and newly admitted to West Point, Bryce showed her how much there was to love about the wind-swept beach town-and introduced her to photography, a passion that would define the rest of her life.",
                Author = userAdmin,
                Publisher = publisherFlatiron,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "87.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyRomance,
                    categoryChildrenHistoricalRomance
                }
            };

            Context.Books.Add(book87);

            var book88 = new Book
            {
                Title = "Every Breath",
                PageCount = 321,
                Price = 32.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 30.99m
                    },
                    new Price
                    {
                        Value = 32.99m
                    }
                },
                ReleaseDate = new DateTime(2018, 4, 24),
                Description = "Treat yourself to an epic #1 New York Times bestselling love story that spans decades and continents as two people at a crossroads -- one from North Carolina and one from Zimbabwe -- experience the transcendence and heartbreak of true love.\r\n\r\nHope Anderson has some important choices to make. At thirty-six, she\\'s been dating her boyfriend, an orthopedic surgeon, for six years. With no wedding plans in sight, and her father recently diagnosed with ALS, she decides to use a week at her family\\'s cottage in Sunset Beach, North Carolina, to ready the house for sale and mull over some difficult decisions about her future.\r\n\r\nTru Walls has never visited North Carolina but is summoned to Sunset Beach by a letter from a man claiming to be his father. A safari guide, born and raised in Zimbabwe, Tru hopes to unravel some of the mysteries surrounding his mother\\'s early life and recapture memories lost with her death. When the two strangers cross paths, their connection is as electric as it is unfathomable . . . but in the immersive days that follow, their feelings for each other will give way to choices that pit family duty against personal happiness in devastating ways.",
                Author = userNicholas,
                Publisher = publisherHouse,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "88.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyRomance
                }
            };

            Context.Books.Add(book88);

            var book89 = new Book
            {
                Title = "The Return",
                PageCount = 369,
                Price = 64.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 60.99m
                    },
                    new Price
                    {
                        Value = 64.99m
                    }
                },
                ReleaseDate = new DateTime(2020, 6, 21),
                Description = "In the romantic tradition of Dear John, an injured Navy doctor meets two extremely important women whose secrets will change the course of his life in this #1 New York Times bestseller.\r\n\r\nTrevor Benson never intended to move back to New Bern, North Carolina. But when a mortar blast outside the hospital where he worked sent him home from Afghanistan with devastating injuries, the dilapidated cabin he\\'d inherited from his grandfather seemed as good a place to regroup as any.\r\n\r\nTending to his grandfather\\'s beloved beehives, Trevor isn\\'t prepared to fall in love with a local . . . yet, from their very first encounter, Trevor feels a connection with deputy sheriff Natalie Masterson that he can\\'t ignore. But even as she seems to reciprocate his feelings, she remains frustratingly distant, making Trevor wonder what she\\'s hiding.",
                Author = userNicholas,
                Publisher = publisherHouse,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "89.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHistoricalRomance
                }
            };

            Context.Books.Add(book89);

            var book90 = new Book
            {
                Title = "The Rescue",
                PageCount = 433,
                Price = 43.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 40.99m
                    },
                    new Price
                    {
                        Value = 43.00m
                    }
                },
                ReleaseDate = new DateTime(2000, 5, 12),
                Description = "In this heartfelt Southern love story from the #1 New York Times bestselling author of The Notebook, a daring fireman rescues a single mom-and learns that falling in love is the greatest risk of all.\r\n\r\nWhen confronted by raging fires or deadly accidents, volunteer fireman Taylor McAden feels compelled to take terrifying risks to save lives. But there is one leap of faith Taylor can\\'t bring himself to make: he can\\'t fall in love. For all his adult years, Taylor has sought out women who need to be rescued, women he leaves as soon as their crisis is over and the relationship starts to become truly intimate.\r\n\r\nWhen a raging storm hits his small Southern town, single mother Denise Holton\\'s car skids off the road. The young mom is with her four-year-old son Kyle, a boy with severe learning disabilities and for whom she has sacrificed everything. Taylor McAden finds her unconscious and bleeding, but does not find Kyle. When Denise wakes, the chilling truth becomes clear to both of them. Kyle is gone. During the search for Kyle, a connection between Taylor and Denise takes root. But Taylor doesn\\'t know that this rescue will be different from all the others.",
                Author = userNicholas,
                Publisher = publisherHouse,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "90.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHistoricalRomance,
                    categoryChildrenFantasyRomance
                }
            };

            Context.Books.Add(book90);

            var book91 = new Book
            {
                Title = "A Bend in the Road",
                PageCount = 388,
                Price = 56.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 53.99m
                    },
                    new Price
                    {
                        Value = 56.00m
                    }
                },
                ReleaseDate = new DateTime(2001, 3, 21),
                Description = "Fall in love with this small-town love story about a widower sheriff and a divorced schoolteacher who are searching for second chances -- only to be threatened by long-held secrets of the past.\r\n\r\nMiles Ryan\\'s life seemed to end the day his wife was killed in a hit-and-run accident two years ago. As deputy sheriff of New Bern, North Carolina, he not only grieves for her and worries about their young son Jonah but longs to bring the unknown driver to justice. Then Miles meets Sarah Andrews, Jonah\\'s second-grade teacher. A young woman recovering from a difficult divorce, Sarah moved to New Bern hoping to start over. Tentatively, Miles and Sarah reach out to each other...soon they are falling in love. But what neither realizes is that they are also bound together by a shocking secret, one that will force them to reexamine everything they believe in-including their love.",
                Author = userNicholas,
                Publisher = publisherHouse,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "91.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyRomance
                }
            };

            Context.Books.Add(book91);

            var book92 = new Book
            {
                Title = "True Believer",
                PageCount = 480,
                Price = 23.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 21.99m
                    },
                    new Price
                    {
                        Value = 23.00m
                    }
                },
                ReleaseDate = new DateTime(2005, 6, 24),
                Description = "Part love story and part ghost story, this is an unforgettable New York Times bestseller about a science journalist and a North Carolina librarian who dare to believe in the impossible.\r\n\r\nAs a science journalist with a regular column in Scientific American, Jeremy Marsh specializes in debunking the supernatural-until he falls in love with the granddaughter of the town psychic.\r\n\r\nWhen Jeremy receives a letter from Boone Creek, North Carolina, about ghostly lights appearing in a cemetery, he can\\'t resist driving down to investigate. Here, in this tightly knit community, Lexie Darnell runs the town\\'s library. Disappointed by past relationships, she is sure of one thing: her future is in Boone Creek, close to all the people she loves. From the moment Jeremy sets eyes on Lexie, he is intrigued. And Lexie, while hesitating to trust this outsider, finds herself thinking of him more than she cares to admit. Now, if they are to be together, Jeremy must do something he\\'s never done before-take a giant leap of faith.",
                Author = userNicholas,
                Publisher = publisherHouse,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "92.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHistoricalRomance
                }
            };

            Context.Books.Add(book92);

            var book93 = new Book
            {
                Title = "The Guardian",
                PageCount = 494,
                Price = 12.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 10.99m
                    },
                    new Price
                    {
                        Value = 12.99m
                    }
                },
                ReleaseDate = new DateTime(2003, 2, 2),
                Description = "After her husband\\'s death, a young widow with a faithful Great Dane must decide between two men -- but as new love blossoms, jealousy turns deadly in this suspenseful New York Times bestseller.\r\n\r\nJulie Barenson\\'s young husband left her two unexpected gifts before he died - a Great Dane puppy named Singer and the promise that he would always be watching over her. Now four years have passed. Still living in the small town of Swansboro, North Carolina, twenty-nine-year-old Julie is emotionally ready to make a commitment to someone again. But who?\r\n\r\nShould it be Richard Franklin, the handsome, sophisticated engineer who treats her like a queen? Or Mike Harris, the down-to-earth nice guy who was her husband\\'s best friend? Choosing one of them should bring her more happiness than she\\'s had in years. Instead, Julie is soon fighting for her life in a nightmare spawned by a chilling deception and jealousy so poisonous that it has become a murderous desire...",
                Author = userNicholas,
                Publisher = publisherHouse,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "93.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyRomance
                }
            };

            Context.Books.Add(book93);

            var book94 = new Book
            {
                Title = "See Me",
                PageCount = 489,
                Price = 34.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 30.99m
                    },
                    new Price
                    {
                        Value = 34.99m
                    }
                },
                ReleaseDate = new DateTime(2015, 8, 24),
                Description = "In this suspenseful New York Times bestseller, a chance encounter between a successful lawyer and a rebellious bad boy will change life as they know it forever, as their pasts catch up with them . . .\r\n\r\nColin Hancock is giving his second chance his best shot. With a history of violence and bad decisions behind him and the threat of prison dogging his every step, he\\'s determined to walk a straight line. To Colin, that means applying himself single-mindedly toward his teaching degree and avoiding everything that proved destructive in his earlier life. Reminding himself daily of his hard-earned lessons, the last thing he is looking for is a serious relationship.\r\n\r\nMaria Sanchez, the hardworking daughter of Mexican immigrants, is the picture of conventional success. With a degree from Duke Law School and a job at a prestigious firm in Wilmington, she is a dark-haired beauty with a seemingly flawless professional track record. And yet Maria has a traumatic history of her own, one that compelled her to return to her hometown and left her questioning so much of what she once believed.",
                Author = userNicholas,
                Publisher = publisherHouse,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "94.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHistoricalRomance
                }
            };

            Context.Books.Add(book94);

            var book95 = new Book
            {
                Title = "Two by Two",
                PageCount = 497,
                Price = 45.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 41.99m
                    },
                    new Price
                    {
                        Value = 45.00m
                    }
                },
                ReleaseDate = new DateTime(2016, 7, 22),
                Description = "In this New York Times bestseller, a single father discovers the true nature of unconditional love when a new chance at happiness turns his world upside down.\r\n\r\nAt 32, Russell Green has it all: a stunning wife, a lovable six year-old daughter, a successful career as an advertising executive, and an expansive home in Charlotte. He is living the dream, and his marriage to the bewitching Vivian is at the center of it. But underneath the shiny surface of this perfect existence, fault lines are beginning to appear . . . and no one is more surprised than Russ when every aspect of the life he has taken for granted is turned upside down.\r\nIn a matter of months, Russ finds himself without a job or a wife, caring for his young daughter while struggling to adapt to a new and baffling reality. Throwing himself into the wilderness of single parenting, Russ embarks on a journey at once terrifying and rewarding -- one that will test his abilities and his emotional resources beyond anything he\\'s ever imagined.\r\n",
                Author = userNicholas,
                Publisher = publisherHouse,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "95.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHistoricalRomance
                }
            };

            Context.Books.Add(book95);

            var book96 = new Book
            {
                Title = "The Choice: The Dragon Heart Legacy",
                PageCount = 438,
                Price = 23.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 21.99m
                    },
                    new Price
                    {
                        Value = 23.99m
                    }
                },
                ReleaseDate = new DateTime(2022, 7, 22),
                Description = "The conclusion of the epic trilogy from the #1 New York Times bestselling author of The Awakening and The Becoming.\r\n\r\nTalamh is a land of green hills, high mountains, deep forests, and seas, where magicks thrive. But portals allow for passage in and out-and ultimately, each must choose their place, and choose between good and evil, war and peace, life and death…\r\n\r\nBreen Siobhan Kelly grew up in the world of Man and was once unaware of her true nature. Now she is in Talamh, trying to heal after a terrible battle and heartbreaking losses. Her grandfather, the dark god Odran, has been defeated in his attempt to rule over Talamh, and over Breen-for now.",
                Author = userNora,
                Publisher = publisherMartins,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "96.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyRomance
                }
            };

            Context.Books.Add(book96);

            var book97 = new Book
            {
                Title = "The Becoming: The Dragon Heart Legacy",
                PageCount = 444,
                Price = 34.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 30.99m
                    },
                    new Price
                    {
                        Value = 34.99m
                    }
                },
                ReleaseDate = new DateTime(2021, 1, 26),
                Description = "A new epic of love and war among gods and humans, from Nora Roberts-the #1 New York Times bestselling author of The Awakening.\r\n\r\nThe world of magick and the world of man have long been estranged from one another. But some can walk between the two-including Breen Siobhan Kelly. She has just returned to Talamh, with her friend, Marco, who\\'s dazzled and disoriented by this realm-a place filled with dragons and faeries and mermaids (but no WiFi, to his chagrin). In Talamh, Breen is not the ordinary young schoolteacher he knew her as. Here she is learning to embrace the powers of her true identity. Marco is welcomed kindly by her people-and by Keegan, leader of the Fey. Keegan has trained Breen as a warrior, and his yearning for her has grown along with his admiration of her strength and skills.\r\n\r\nBut one member of Breen\\'s bloodline is not there to embrace her. Her grandfather, the outcast god Odran, plots to destroy Talamh-and now all must unite to defeat his dark forces. There will be losses and sorrows, betrayal and bloodshed. But through it, Breen Siobhan Kelly will take the next step on the journey to becoming all that she was born to be.",
                Author = userNora,
                Publisher = publisherMartins,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "97.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyRomance
                }
            };

            Context.Books.Add(book97);

            var book98 = new Book
            {
                Title = "The Awakening: The Dragon Heart Legacy",
                PageCount = 345,
                Price = 23.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 21.99m
                    },
                    new Price
                    {
                        Value = 23.99m
                    }
                },
                ReleaseDate = new DateTime(2020, 3, 21),
                Description = "#1 New York Times bestselling author Nora Roberts begins a new trilogy of adventure, romance, and magick in The Awakening.\r\n\r\nIn the realm of Talamh, a teenage warrior named Keegan emerges from a lake holding a sword-representing both power and the terrifying responsibility to protect the Fey. In another realm known as Philadelphia, a young woman has just discovered she possesses a treasure of her own…\r\n\r\nWhen Breen Kelly was a girl, her father would tell her stories of magical places. Now she\\'s an anxious twentysomething mired in student debt and working a job she hates. But one day she stumbles upon a shocking discovery: her mother has been hiding an investment account in her name. It has been funded by her long-lost father-and it\\'s worth nearly four million dollars.",
                Author = userNora,
                Publisher = publisherMartins,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "98.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyRomance
                }
            };

            Context.Books.Add(book98);

            var book99 = new Book
            {
                Title = "Nightwork",
                PageCount = 440,
                Price = 54.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 52.99m
                    },
                    new Price
                    {
                        Value = 54.99m
                    }
                },
                ReleaseDate = new DateTime(2022, 4, 24),
                Description = "#1 New York Times bestselling author Nora Roberts introduces an unforgettable thief in an unputdownable new novel…\r\n\r\nGreed. Desire. Obsession. Revenge . . . It\\'s all in a night\\'s work.\r\n\r\nHarry Booth started stealing at nine to keep a roof over his ailing mother\\'s head, slipping into luxurious, empty homes at night to find items he could trade for precious cash. When his mother finally succumbed to cancer, he left Chicago-but kept up his nightwork, developing into a master thief with a code of honor and an expertise in not attracting attention?or getting attached.",
                Author = userNora,
                Publisher = publisherMartins,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "99.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyRomance
                }
            };

            Context.Books.Add(book99);

            var book100 = new Book
            {
                Title = "Courting Catherine: The Calhoun Women",
                PageCount = 141,
                Price = 34.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 31.99m
                    },
                    new Price
                    {
                        Value = 34.99m
                    }
                },
                ReleaseDate = new DateTime(2020, 3, 22),
                Description = "First in The Calhoun Women series, #1 New York Times bestselling author Nora Roberts\\'s Courting Catherine begins a story of sisters bound by their family\\'s ancestral home and determined to forge their own futures.\r\n\r\nThe once grand mansion known as the Towers has stood on the Maine coast for decades. It was supposed to symbolize the Calhoun family legacy, but instead has fallen into a desperate state of disrepair. Catherine \\\\\"C. C.\\\\\" Calhoun and her sisters have inherited both the mansion and the responsibility of restoring the Towers back to its former glory-only to struggle with escalating costs.\r\n\r\nHotelier Trenton St. James believes the estate\\'s time has passed and that the town would be served better if the property were converted into a luxury resort. But his business negotiation skills fail to persuade C. C.-whose fighting spirit and driving passions capture his heart and compel him to build something more loving and lasting between them.",
                Author = userNora,
                Publisher = publisherMartins,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "100.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyRomance
                }
            };

            Context.Books.Add(book100);

            var book101 = new Book
            {
                Title = "Truman",
                PageCount = 257,
                Price = 17.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 17.99m
                    }
                },
                ReleaseDate = new DateTime(2011, 3, 26),
                Description = "The Pulitzer Prize-winning biography of Harry S. Truman, whose presidency included momentous events from the atomic bombing of Japan to the outbreak of the Cold War and the Korean War, told by America\\'s beloved and distinguished historian.\r\n\r\nThe life of Harry S. Truman is one of the greatest of American stories, filled with vivid characters-Roosevelt, Churchill, Stalin, Eleanor Roosevelt, Bess Wallace Truman, George Marshall, Joe McCarthy, and Dean Acheson-and dramatic events. In this riveting biography, acclaimed historian David McCullough not only captures the man-a more complex, informed, and determined man than ever before imagined-but also the turbulent times in which he rose, boldly, to meet unprecedented challenges. The last president to serve as a living link between the nineteenth and the twentieth centuries, Truman\\'s story spans the raw world of the Missouri frontier, World War I, the powerful Pendergast machine of Kansas City, the legendary Whistle-Stop Campaign of 1948, and the decisions to drop the atomic bomb, confront Stalin at Potsdam, send troops to Korea, and fire General MacArthur. Drawing on newly discovered archival material and extensive interviews with Truman\\'s own family, friends, and Washington colleagues, McCullough tells the deeply moving story of the seemingly ordinary \"man from Missouri\" who was perhaps the most courageous president in our history.",
                Author = userDavid,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "101.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenSocialHistory,
                    categoryChildrenCulturalHistory
                }
            };

            Context.Books.Add(book101);

            var book102 = new Book
            {
                Title = "The Path Between the Seas",
                PageCount = 420,
                Price = 12.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 10.99m
                    },
                    new Price
                    {
                        Value = 12.99m
                    }
                },
                ReleaseDate = new DateTime(2001, 9, 3),
                Description = "The National Book Award-winning epic chronicle of the creation of the Panama Canal, a first-rate drama of the bold and brilliant engineering feat that was filled with both tragedy and triumph, told by master historian David McCullough.\r\n\r\nFrom the Pulitzer Prize-winning author of Truman, here is the national bestselling epic chronicle of the creation of the Panama Canal. In The Path Between the Seas, acclaimed historian David McCullough delivers a first-rate drama of the sweeping human undertaking that led to the creation of this grand enterprise.\r\n\r\nThe Path Between the Seas tells the story of the men and women who fought against all odds to fulfill the 400-year-old dream of constructing an aquatic passageway between the Atlantic and Pacific oceans. It is a story of astonishing engineering feats, tremendous medical accomplishments, political power plays, heroic successes, and tragic failures. Applying his remarkable gift for writing lucid, lively exposition, McCullough weaves the many strands of the momentous event into a comprehensive and captivating tale.",
                Author = userDavid,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "102.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalHistory
                }
            };

            Context.Books.Add(book102);

            var book103 = new Book
            {
                Title = "The Pioneers",
                PageCount = 353,
                Price = 43.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 40.99m
                    },
                    new Price
                    {
                        Value = 43.99m
                    }
                },
                ReleaseDate = new DateTime(2019, 1, 4),
                Description = "The #1 New York Times bestseller by Pulitzer Prize-winning historian David McCullough rediscovers an important chapter in the American story that\\'s \\\\\"as resonant today as ever\\\\\" (The Wall Street Journal)-the settling of the Northwest Territory by courageous pioneers who overcame incredible hardships to build a community based on ideals that would define our country.\r\n\r\nAs part of the Treaty of Paris, in which Great Britain recognized the new United States of America, Britain ceded the land that comprised the immense Northwest Territory, a wilderness empire northwest of the Ohio River containing the future states of Ohio, Indiana, Illinois, Michigan, and Wisconsin. A Massachusetts minister named Manasseh Cutler was instrumental in opening this vast territory to veterans of the Revolutionary War and their families for settlement. Included in the Northwest Ordinance were three remarkable conditions: freedom of religion, free universal education, and most importantly, the prohibition of slavery. In 1788 the first band of pioneers set out from New England for the Northwest Territory under the leadership of Revolutionary War veteran General Rufus Putnam. They settled in what is now Marietta on the banks of the Ohio River\r\n\r\nMcCullough tells the story through five major characters: Cutler and Putnam; Cutler\\'s son Ephraim; and two other men, one a carpenter turned architect, and the other a physician who became a prominent pioneer in American science. \"With clarity and incisiveness, [McCullough] details the experience of a brave and broad-minded band of people who crossed raging rivers, chopped down forests, plowed miles of land, suffered incalculable hardships, and braved a lonely frontier to forge a new American ideal\" (The Providence Journal).",
                Author = userDavid,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "103.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenSocialHistory
                }
            };

            Context.Books.Add(book103);

            var book104 = new Book
            {
                Title = "1776",
                PageCount = 365,
                Price = 54.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 51.99m
                    },
                    new Price
                    {
                        Value = 54.99m
                    }
                },
                ReleaseDate = new DateTime(2005, 5, 3),
                Description = "America\\'s beloved and distinguished historian presents, in a book of breathtaking excitement, drama, and narrative force, the stirring story of the year of our nation\\'s birth, 1776, interweaving, on both sides of the Atlantic, the actions and decisions that led Great Britain to undertake a war against her rebellious colonial subjects and that placed America\\'s survival in the hands of George Washington.\r\n\r\nIn this masterful book, David McCullough tells the intensely human story of those who marched with General George Washington in the year of the Declaration of Independence-when the whole American cause was riding on their success, without which all hope for independence would have been dashed and the noble ideals of the Declaration would have amounted to little more than words on paper.",
                Author = userDavid,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "104.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenSocialHistory
                }
            };

            Context.Books.Add(book104);

            var book105 = new Book
            {
                Title = "The Great Bridge",
                PageCount = 609,
                Price = 34.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 31.99m
                    },
                    new Price
                    {
                        Value = 34.99m
                    }
                },
                ReleaseDate = new DateTime(2007, 3, 21),
                Description = "The dramatic and enthralling story of the building of the Brooklyn Bridge, the world\\'s longest suspension bridge at the time, a tale of greed, corruption, and obstruction but also of optimism, heroism, and determination, told by master historian David McCullough.\r\n\r\nThis monumental book is the enthralling story of one of the greatest events in our nation\\'s history, during the Age of Optimism-a period when Americans were convinced in their hearts that all things were possible.\r\n\r\nIn the years around 1870, when the project was first undertaken, the concept of building an unprecedented bridge to span the East River between the great cities of Manhattan and Brooklyn required a vision and determination comparable to that which went into the building of the great cathedrals. Throughout the fourteen years of its construction, the odds against the successful completion of the bridge seemed staggering. Bodies were crushed and broken, lives lost, political empires fell, and surges of public emotion constantly threatened the project. But this is not merely the saga of an engineering miracle; it is a sweeping narrative of the social climate of the time and of the heroes and rascals who had a hand in either constructing or exploiting the surpassing enterprise.",
                Author = userDavid,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "105.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalHistory
                }
            };

            Context.Books.Add(book105);

            var book106 = new Book
            {
                Title = "The Wright Brothers",
                PageCount = 56,
                Price = 23.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 21.99m
                    },
                    new Price
                    {
                        Value = 23.99m
                    }
                },
                ReleaseDate = new DateTime(2022, 5, 1),
                Description = "The aim of this book has been to satisfy the curiosity of the average, non-technical reader regarding the work of the Wright Brothers, and to do so as simply as possible. This book has been vetted for accuracy by Orville Wright himself, who has read the manuscript and given generously of his time in verifying the accuracy of various statements and in correcting inaccuracies that otherwise would have appeared.",
                Author = userDavid,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "106.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenSocialHistory
                }
            };

            Context.Books.Add(book106);

            var book107 = new Book
            {
                Title = "John Adams",
                PageCount = 752,
                Price = 34.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 31.99m
                    },
                    new Price
                    {
                        Value = 34.99m
                    }
                },
                ReleaseDate = new DateTime(2001, 12, 1),
                Description = "The Pulitzer Prize-winning, bestselling biography of America\\'s founding father and second president that was the basis for the acclaimed HBO series, brilliantly told by master historian David McCullough.\r\n\r\nIn this powerful, epic biography, David McCullough unfolds the adventurous life journey of John Adams, the brilliant, fiercely independent, often irascible, always honest Yankee patriot who spared nothing in his zeal for the American Revolution; who rose to become the second president of the United States and saved the country from blundering into an unnecessary war; who was learned beyond all but a few and regarded by some as \"out of his senses\"; and whose marriage to the wise and valiant Abigail Adams is one of the moving love stories in American history.\r\n\r\nThis is history on a grand scale-a book about politics and war and social issues, but also about human nature, love, religious faith, virtue, ambition, friendship, and betrayal, and the far-reaching consequences of noble ideas. Above all, John Adams is an enthralling, often surprising story of one of the most important and fascinating Americans who ever lived.",
                Author = userDavid,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "107.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalHistory
                }
            };

            Context.Books.Add(book107);

            var book108 = new Book
            {
                Title = "Brave Companions",
                PageCount = 258,
                Price = 23.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 21.99m
                    },
                    new Price
                    {
                        Value = 23.99m
                    }
                },
                ReleaseDate = new DateTime(2007, 7, 1),
                Description = "From Alexander von Humboldt to Charles and Anne Lindbergh, these are stories of people of great vision and daring whose achievements continue to inspire us today, brilliantly told by master historian David McCullough.\r\n\r\nThe bestselling author of Truman and John Adams, David McCullough has written profiles of exceptional men and women past and present who have not only shaped the course of history or changed how we see the world but whose stories express much that is timeless about the human condition.\r\n\r\nHere are Alexander von Humboldt, whose epic explorations of South America surpassed the Lewis and Clark expedition; Harriet Beecher Stowe, \"the little woman who made the big war\"; Frederic Remington; the extraordinary Louis Agassiz of Harvard; Charles and Anne Lindbergh, and their fellow long-distance pilots Antoine de Saint-Exupéry and Beryl Markham; Harry Caudill, the Kentucky lawyer who awakened the nation to the tragedy of Appalachia; and David Plowden, a present-day photographer of vanishing America.",
                Author = userDavid,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "108.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalHistory,
                    categoryChildrenSocialHistory
                }
            };

            Context.Books.Add(book108);

            var book109 = new Book
            {
                Title = "Mornings on Horseback",
                PageCount = 450,
                Price = 23.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 21.99m
                    },
                    new Price
                    {
                        Value = 23.99m
                    }
                },
                ReleaseDate = new DateTime(2007, 7, 2),
                Description = "The National Book Award-winning biography that tells the story of how young Teddy Roosevelt transformed himself from a sickly boy into the vigorous man who would become a war hero and ultimately president of the United States, told by master historian David McCullough.\r\n\r\nMornings on Horseback is the brilliant biography of the young Theodore Roosevelt. Hailed as \\\\\"a masterpiece\\\\\" (John A. Gable, Newsday), it is the winner of the Los Angeles Times 1981 Book Prize for Biography and the National Book Award for Biography. Written by David McCullough, the author of Truman, this is the story of a remarkable little boy, seriously handicapped by recurrent and almost fatal asthma attacks, and his struggle to manhood: an amazing metamorphosis seen in the context of the very uncommon household in which he was raised.\r\n\r\nThe father is the first Theodore Roosevelt, a figure of unbounded energy, enormously attractive and selfless, a god in the eyes of his small, frail namesake. The mother, Mittie Bulloch Roosevelt, is a Southerner and a celebrated beauty, but also considerably more, which the book makes clear as never before. There are sisters Anna and Corinne, brother Elliott (who becomes the father of Eleanor Roosevelt), and the lovely, tragic Alice Lee, TR\\'s first love. All are brought to life to make \"a beautifully told story, filled with fresh detail\" (The New York Times Book Review).",
                Author = userDavid,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "109.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalHistory
                }
            };

            Context.Books.Add(book109);

            var book110 = new Book
            {
                Title = "Johnstown Flood",
                PageCount = 443,
                Price = 34.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 31.99m
                    },
                    new Price
                    {
                        Value = 34.99m
                    }
                },
                ReleaseDate = new DateTime(2007, 1, 31),
                Description = "The stunning story of one of America\\'s great disasters, a preventable tragedy of Gilded Age America, brilliantly told by master historian David McCullough.\r\n\r\nAt the end of the nineteenth century, Johnstown, Pennsylvania, was a booming coal-and-steel town filled with hardworking families striving for a piece of the nation\\'s burgeoning industrial prosperity. In the mountains above Johnstown, an old earth dam had been hastily rebuilt to create a lake for an exclusive summer resort patronized by the tycoons of that same industrial prosperity, among them Andrew Carnegie, Henry Clay Frick, and Andrew Mellon. Despite repeated warnings of possible danger, nothing was done about the dam. Then came May 31, 1889, when the dam burst, sending a wall of water thundering down the mountain, smashing through Johnstown, and killing more than 2,000 people. It was a tragedy that became a national scandal.\r\n\r\nGraced by David McCullough\\'s remarkable gift for writing richly textured, sympathetic social history, The Johnstown Flood is an absorbing, classic portrait of life in nineteenth-century America, of overweening confidence, of energy, and of tragedy. It also offers a powerful historical lesson for our century and all times: the danger of assuming that because people are in positions of responsibility they are necessarily behaving responsibly.",
                Author = userDavid,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "110.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalHistory
                }
            };

            Context.Books.Add(book110);

            var book111 = new Book
            {
                Title = "Team of Rivals",
                PageCount = 954,
                Price = 35.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 34.99m
                    },
                    new Price
                    {
                        Value = 35.99m
                    }
                },
                ReleaseDate = new DateTime(2006, 12, 6),
                Description = "Winner of the Lincoln Prize\r\n\r\nAcclaimed historian Doris Kearns Goodwin illuminates Abraham Lincoln\\'s political genius in this highly original work, as the one-term congressman and prairie lawyer rises from obscurity to prevail over three gifted rivals of national reputation to become president.\r\n\r\nOn May 18, 1860, William H. Seward, Salmon P. Chase, Edward Bates, and Abraham Lincoln waited in their hometowns for the results from the Republican National Convention in Chicago. When Lincoln emerged as the victor, his rivals were dismayed and angry.",
                Author = userDoris,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "111.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalHistory,
                    categoryChildrenSocialHistory
                }
            };

            Context.Books.Add(book111);

            var book112 = new Book
            {
                Title = "No Ordinary Time",
                PageCount = 771,
                Price = 12.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 11.99m
                    },
                    new Price
                    {
                        Value = 12.99m
                    }
                },
                ReleaseDate = new DateTime(2008, 5, 1),
                Description = "Doris Kearns Goodwin\\'s Pulitzer Prize-winning classic about the relationship between Franklin D. Roosevelt and Eleanor Roosevelt, and how it shaped the nation while steering it through the Great Depression and the outset of World War II.\r\n\r\nWith an extraordinary collection of details, Goodwin masterfully weaves together a striking number of story lines-Eleanor and Franklin\\'s marriage and remarkable partnership, Eleanor\\'s life as First Lady, and FDR\\'s White House and its impact on America as well as on a world at war. Goodwin effectively melds these details and stories into an unforgettable and intimate portrait of Eleanor and Franklin Roosevelt and of the time during which a new, modern America was born.",
                Author = userDoris,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "112.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalHistory
                }
            };

            Context.Books.Add(book112);

            var book113 = new Book
            {
                Title = "Lincoln",
                PageCount = 194,
                Price = 23.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 21.99m
                    },
                    new Price
                    {
                        Value = 23.99m
                    }
                },
                ReleaseDate = new DateTime(2013, 3, 6),
                Description = "\"All forward thrust and hot-damn urgency…A brilliant, brawling epic. Screenwriter Tony Kushner blows the dust off history by investing it with flesh, blood, and churning purpose. . . . A great American movie.\" -Peter Travers, Rolling Stone\r\n\r\n\"Lincoln is a rough and noble democratic masterpiece. And the genius of Lincoln, finally, lies in its vision of politics as a noble, sometimes clumsy dialectic of the exalted and the mundane…And Mr. Kushner, whose love of passionate, exhaustive disputation is unmatched in the modern theater, fills nearly every scene with wonderful, maddening talk. Go see this movie.\" -A.O. Scott, New York Times\r\n\r\n\"A lyrical, ingeniously structured screenplay. Lincoln is one of the most authentic biographical dramas I\\'ve ever seen…grand and immersive. It plugs us into the final months of Lincoln\\'s presidency with a purity that makes us feel transported as if by time machine.\" -Owen Gleiberman, Entertainment Weekly",
                Author = userDoris,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "116.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalHistory
                }
            };

            Context.Books.Add(book113);

            var book114 = new Book
            {
                Title = "Leadership",
                PageCount = 497,
                Price = 36.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 34.99m
                    },
                    new Price
                    {
                        Value = 36.99m
                    }
                },
                ReleaseDate = new DateTime(2018, 8, 3),
                Description = "From Pulitzer Prize-winning author and esteemed presidential historian Doris Kearns Goodwin, an invaluable guide to the development and exercise of leadership from Abraham Lincoln, Theodore Roosevelt, Lyndon B. Johnson, and Franklin D. Roosevelt.\r\n\r\nThe inspiration for the multipart HISTORY Channel series Abraham Lincoln and Theodore Roosevelt.\r\n\r\n\"After five decades of magisterial output, Doris Kearns Goodwin leads the league of presidential historians\" (USA TODAY). In her \"inspiring\" (The Christian Science Monitor) Leadership, Doris Kearns Goodwin draws upon the four presidents she has studied most closely-Abraham Lincoln, Theodore Roosevelt, Franklin D. Roosevelt, and Lyndon B. Johnson (in civil rights)-to show how they recognized leadership qualities within themselves and were recognized as leaders by others. By looking back to their first entries into public life, we encounter them at a time when their paths were filled with confusion, fear, and hope.",
                Author = userDoris,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "114.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenCulturalHistory,
                    categoryChildrenSocialHistory
                }
            };

            Context.Books.Add(book114);

            var book115 = new Book
            {
                Title = "The Bully Pulpit",
                PageCount = 929,
                Price = 37.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 34.99m
                    },
                    new Price
                    {
                        Value = 37.99m
                    }
                },
                ReleaseDate = new DateTime(2013, 4, 2),
                Description = "Pulitzer Prize-winning author and presidential historian Doris Kearns Goodwin\\'s dynamic history of Theodore Roosevelt, William H. Taft and the first decade of the Progressive era, that tumultuous time when the nation was coming unseamed and reform was in the air.\r\n\r\nWinner of the Carnegie Medal.\r\n\r\nDoris Kearns Goodwin\\'s The Bully Pulpit is a dynamic history of the first decade of the Progressive era, that tumultuous time when the nation was coming unseamed and reform was in the air.",
                Author = userDoris,
                Publisher = publisherSimon,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "115.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenSocialHistory
                }
            };

            Context.Books.Add(book115);

            var book116 = new Book
            {
                Title = "Talking to Strangers",
                PageCount = 401,
                Price = 23.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 21.99m
                    },
                    new Price
                    {
                        Value = 23.99m
                    }
                },
                ReleaseDate = new DateTime(2019, 2, 3),
                Description = "Malcolm Gladwell, host of the podcast Revisionist History and author of the #1 New York Times bestseller Outliers, offers a powerful examination of our interactions with strangers and why they often go wrong-now with a new afterword by the author.\r\n\r\nA Best Book of the Year: The Financial Times, Bloomberg, Chicago Tribune, and Detroit Free Press\r\n\r\nHow did Fidel Castro fool the CIA for a generation? Why did Neville Chamberlain think he could trust Adolf Hitler? Why are campus sexual assaults on the rise? Do television sitcoms teach us something about the way we relate to one another that isn\\'t true?",
                Author = userMalcolm,
                Publisher = publisherLittle,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "113.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenSocialHistory
                }
            };

            Context.Books.Add(book116);

            var book117 = new Book
            {
                Title = "David and Goliath",
                PageCount = 322,
                Price = 45.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 44.99m
                    },
                    new Price
                    {
                        Value = 45.99m
                    }
                },
                ReleaseDate = new DateTime(2013, 4, 2),
                Description = "Explore the power of the underdog in Malcolm Gladwell\\'s dazzling examination of success, motivation, and the role of adversity in shaping our lives, from the bestselling author of The Bomber Mafia.\r\n\r\nThree thousand years ago on a battlefield in ancient Palestine, a shepherd boy felled a mighty warrior with nothing more than a stone and a sling, and ever since then the names of David and Goliath have stood for battles between underdogs and giants. David\\'s victory was improbable and miraculous. He shouldn\\'t have won.\r\n\r\nIn David and Goliath, Malcolm Gladwellchallenges how we think about obstacles and disadvantages, offering a new interpretation of what it means to be discriminated against, or cope with a disability, or lose a parent, or attend a mediocre school, or suffer from any number of other apparent setbacks.",
                Author = userMalcolm,
                Publisher = publisherLittle,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "117.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenManagementBusiness
                }
            };

            Context.Books.Add(book117);

            var book118 = new Book
            {
                Title = "Outliers",
                PageCount = 321,
                Price = 32.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 31.99m
                    },
                    new Price
                    {
                        Value = 32.99m
                    }
                },
                ReleaseDate = new DateTime(2008, 6, 4),
                Description = "Malcolm Gladwell, bestselling author of Blink and The Bomber Mafia and host of the podcast Revisionist History, explores what sets high achievers apart-from Bill Gates to the Beatles-in this seminal work from \"a singular talent\" (New York Times Book Review).\r\n\r\nIn this stunning book, Malcolm Gladwell takes us on an intellectual journey through the world of \"outliers\"-the best and the brightest, the most famous and the most successful. He asks the question: what makes high-achievers different?\r\n\r\nHis answer is that we pay too much attention to what successful people are like, and too little attention to where they are from: that is, their culture, their family, their generation, and the idiosyncratic experiences of their upbringing. Along the way he explains the secrets of software billionaires, what it takes to be a great soccer player, why Asians are good at math, and what made the Beatles the greatest rock band.",
                Author = userMalcolm,
                Publisher = publisherLittle,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "118.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenPersonalImprovement,
                    categoryChildrenCommunicationImprovement,
                    categoryChildrenManagementBusiness
                }
            };

            Context.Books.Add(book118);

            var book119 = new Book
            {
                Title = "Blink",
                PageCount = 296,
                Price = 12.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 10.99m
                    },
                    new Price
                    {
                        Value = 12.99m
                    }
                },
                ReleaseDate = new DateTime(2007, 4, 16),
                Description = "From the #1 bestselling author of The Bomber Mafia, the landmark book that has revolutionized the way we understand leadership and decision making.\r\n\r\nIn his breakthrough bestseller The Tipping Point, Malcolm Gladwell redefined how we understand the world around us. Now, in Blink, he revolutionizes the way we understand the world within. Blink is a book about how we think without thinking, about choices that seem to be made in an instant--in the blink of an eye--that actually aren\\'t as simple as they seem. Why are some people brilliant decision makers, while others are consistently inept? Why do some people follow their instincts and win, while others end up stumbling into error? How do our brains really work--in the office, in the classroom, in the kitchen, and in the bedroom? And why are the best decisions often those that are impossible to explain to others? In Blink we meet the psychologist who has learned to predict whether a marriage will last, based on a few minutes of observing a couple; the tennis coach who knows when a player will double-fault before the racket even makes contact with the ball; the antiquities experts who recognize a fake at a glance.",
                Author = userMalcolm,
                Publisher = publisherLittle,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "119.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenManagementBusiness,
                    categoryChildrenPersonalImprovement
                }
            };

            Context.Books.Add(book119);

            var book120 = new Book
            {
                Title = "The Tipping Point",
                PageCount = 298,
                Price = 23.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 21.99m
                    },
                    new Price
                    {
                        Value = 23.99m
                    }
                },
                ReleaseDate = new DateTime(2006, 1, 22),
                Description = "From the bestselling author of The Bomber Mafia: discover Malcolm Gladwell\\'s breakthrough debut and explore the science behind viral trends in business, marketing, and human behavior.\r\n\r\nThe tipping point is that magic moment when an idea, trend, or social behavior crosses a threshold, tips, and spreads like wildfire. Just as a single sick person can start an epidemic of the flu, so too can a small but precisely targeted push cause a fashion trend, the popularity of a new product, or a drop in the crime rate. This widely acclaimed bestseller, in which Malcolm Gladwell explores and brilliantly illuminates the tipping point phenomenon, is already changing the way people throughout the world think about selling products and disseminating ideas.\r\n\r\n\"A wonderful page-turner about a fascinating idea that should affect the way every thinking person looks at the world.\" -Michael Lewis",
                Author = userMalcolm,
                Publisher = publisherLittle,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "120.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenPersonalImprovement,
                    categoryChildrenManagementBusiness
                }
            };

            Context.Books.Add(book120);

            var book121 = new Book
            {
                Title = "The Big Shor",
                PageCount = 287,
                Price = 15.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 15.99m
                    }
                },
                ReleaseDate = new DateTime(2010, 5, 12),
                Description = "The #1 New York Times bestseller: \"It is the work of our greatest financial journalist, at the top of his game. And it\\'s essential reading.\" - Graydon Carter, Vanity Fair\r\n\r\nThe real story of the crash began in bizarre feeder markets where the sun doesn\\'t shine and the SEC doesn\\'t dare, or bother, to tread: the bond and real estate derivative markets where geeks invent impenetrable securities to profit from the misery of lower- and middle-class Americans who can\\'t pay their debts. The smart people who understood what was or might be happening were paralyzed by hope and fear; in any case, they weren\\'t talking.\r\n\r\nMichael Lewis creates a fresh, character-driven narrative brimming with indignation and dark humor, a fitting sequel to his #1 bestseller Liar\\'s Poker. Out of a handful of unlikely-really unlikely-heroes, Lewis fashions a story as compelling and unusual as any of his earlier bestsellers, proving yet again that he is the finest and funniest chronicler of our time.",
                Author = userMichael,
                Publisher = publisherNorton,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "121.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenManagementBusiness,
                    categoryChildrenFinanceBusiness
                }
            };

            Context.Books.Add(book121);

            var book122 = new Book
            {
                Title = "Liar\'s Poker",
                PageCount = 352,
                Price = 17.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 17.99m
                    }
                },
                ReleaseDate = new DateTime(2012, 3, 4),
                Description = "The time was the 1980s. The place was Wall Street. The game was called Liar\\'s Poker.\r\n\r\nMichael Lewis was fresh out of Princeton and the London School of Economics when he landed a job at Salomon Brothers, one of Wall Street\\'s premier investment firms. During the next three years, Lewis rose from callow trainee to bond salesman, raking in millions for the firm and cashing in on a modern-day gold rush. Liar\\'s Poker is the culmination of those heady, frenzied years-a behind-the-scenes look at a unique and turbulent time in American business. From the frat-boy camaraderie of the forty-first-floor trading room to the killer instinct that made ambitious young men gamble everything on a high-stakes game of bluffing and deception, here is Michael Lewis\\'s knowing and hilarious insider\\'s account of an unprecedented era of greed, gluttony, and outrageous fortune.",
                Author = userMichael,
                Publisher = publisherNorton,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "122.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFinanceBusiness
                }
            };

            Context.Books.Add(book122);

            var book123 = new Book
            {
                Title = "Moneyball",
                PageCount = 316,
                Price = 11.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 7.99m
                    },
                    new Price
                    {
                        Value = 11.99m
                    }
                },
                ReleaseDate = new DateTime(2004, 3, 17),
                Description = "Michael Lewis\\'s instant classic may be \"the most influential book on sports ever written\" (People), but \"you need know absolutely nothing about baseball to appreciate the wit, snap, economy and incisiveness of [Lewis\\'s] thoughts about it\" (Janet Maslin, New York Times).\r\n\r\nOne of GQ\\'s 50 Best Books of Literary Journalism of the 21st Century\r\n\r\nJust before the 2002 season opens, the Oakland Athletics must relinquish its three most prominent (and expensive) players and is written off by just about everyone-but then comes roaring back to challenge the American League record for consecutive wins. How did one of the poorest teams in baseball win so many games?\r\n",
                Author = userMichael,
                Publisher = publisherNorton,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "123.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFinanceBusiness,
                    categoryChildrenPersonalImprovement
                }
            };

            Context.Books.Add(book123);

            var book124 = new Book
            {
                Title = "The Fifth Risk",
                PageCount = 255,
                Price = 17.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 16.99m
                    },
                    new Price
                    {
                        Value = 17.99m
                    }
                },
                ReleaseDate = new DateTime(2018, 3, 2),
                Description = "The New York Times Bestseller, with a new afterword\r\n\r\n\"[Michael Lewis\\'s] most ambitious and important book.\" -Joe Klein, New York Times\r\n\r\nMichael Lewis\\'s brilliant narrative of the Trump administration\\'s botched presidential transition takes us into the engine rooms of a government under attack by its leaders through willful ignorance and greed. The government manages a vast array of critical services that keep us safe and underpin our lives from ensuring the safety of our food and drugs and predicting extreme weather events to tracking and locating black market uranium before the terrorists do. The Fifth Risk masterfully and vividly unspools the consequences if the people given control over our government have no idea how it works.",
                Author = userMichael,
                Publisher = publisherNorton,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "124.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFinanceBusiness
                }
            };

            Context.Books.Add(book124);

            var book125 = new Book
            {
                Title = "The Undoing Project",
                PageCount = 369,
                Price = 45.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 42.99m
                    },
                    new Price
                    {
                        Value = 45.00m
                    }
                },
                ReleaseDate = new DateTime(2012, 12, 6),
                Description = "\"Brilliant. . . . Lewis has given us a spectacular account of two great men who faced up to uncertainty and the limits of human reason.\" —William Easterly, Wall Street Journal\r\n\r\nForty years ago, Israeli psychologists Daniel Kahneman and Amos Tversky wrote a series of breathtakingly original papers that invented the field of behavioral economics. One of the greatest partnerships in the history of science, Kahneman and Tversky\\'s extraordinary friendship incited a revolution in Big Data studies, advanced evidence-based medicine, led to a new approach to government regulation, and made much of Michael Lewis\\'s own work possible. In The Undoing Project, Lewis shows how their Nobel Prize-winning theory of the mind altered our perception of reality.",
                Author = userMichael,
                Publisher = publisherNorton,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "125.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFinanceBusiness,
                    categoryChildrenManagementBusiness
                }
            };

            Context.Books.Add(book125);

            var book126 = new Book
            {
                Title = "Harry Potter and the Prisoner of Azkaban",
                PageCount = 180,
                Price = 15.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 12.99m
                    },
                    new Price
                    {
                        Value = 15.00m
                    }
                },
                ReleaseDate = new DateTime(2015, 3, 21),
                Description = "\\'Welcome to the Knight Bus, emergency transport for the stranded witch or wizard. Just stick out your wand hand, step on board and we can take you anywhere you want to go.\\'\r\n\r\nWhen the Knight Bus crashes through the darkness and screeches to a halt in front of him, it\\'s the start of another far from ordinary year at Hogwarts for Harry Potter. Sirius Black, escaped mass-murderer and follower of Lord Voldemort, is on the run - and they say he is coming after Harry. In his first ever Divination class, Professor Trelawney sees an omen of death in Harry\\'s tea leaves... But perhaps most terrifying of all are the Dementors patrolling the school grounds, with their soul-sucking kiss...\r\n\r\nHaving become classics of our time, the Harry Potter eBooks never fail to bring comfort and escapism. With their message of hope, belonging and the enduring power of truth and love, the story of the Boy Who Lived continues to delight generations of new readers.",
                Author = userJoanne,
                Publisher = publisherPottermore,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "126.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFinanceBusiness
                }
            };

            Context.Books.Add(book126);

            var book127 = new Book
            {
                Title = "Harry Potter and the Goblet of Fire",
                PageCount = 301,
                Price = 16.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 16.99m
                    }
                },
                ReleaseDate = new DateTime(2015, 12, 8),
                Description = "\\'There will be three tasks, spaced throughout the school year, and they will test the champions in many different ways ... their magical prowess - their daring - their powers of deduction - and, of course, their ability to cope with danger.\\'\r\n\r\nThe Triwizard Tournament is to be held at Hogwarts. Only wizards who are over seventeen are allowed to enter - but that doesn\\'t stop Harry dreaming that he will win the competition. Then at Hallowe\\'en, when the Goblet of Fire makes its selection, Harry is amazed to find his name is one of those that the magical cup picks out. He will face death-defying tasks, dragons and Dark wizards, but with the help of his best friends, Ron and Hermione, he might just make it through - alive!\r\n\r\nHaving become classics of our time, the Harry Potter eBooks never fail to bring comfort and escapism. With their message of hope, belonging and the enduring power of truth and love, the story of the Boy Who Lived continues to delight generations of new readers.",
                Author = userJoanne,
                Publisher = publisherPottermore,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "127.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenThrillersMistery,
                    categoryChildrenFictionChildren,
                    categoryChildrenFantasyFiction
                }
            };

            Context.Books.Add(book127);

            var book128 = new Book
            {
                Title = "Harry Potter and the Half-Blood Prince",
                PageCount = 652,
                Price = 15.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 13.99m
                    },
                    new Price
                    {
                        Value = 15.99m
                    }
                },
                ReleaseDate = new DateTime(2015, 3, 1),
                Description = "There it was, hanging in the sky above the school: the blazing green skull with a serpent tongue, the mark Death Eaters left behind whenever they had entered a building... wherever they had murdered...\r\n\r\nWhen Dumbledore arrives at Privet Drive one summer night to collect Harry Potter, his wand hand is blackened and shrivelled, but he does not reveal why. Secrets and suspicion are spreading through the wizarding world, and Hogwarts itself is not safe. Harry is convinced that Malfoy bears the Dark Mark: there is a Death Eater amongst them. Harry will need powerful magic and true friends as he explores Voldemort\\'s darkest secrets, and Dumbledore prepares him to face his destiny...\r\n\r\nHaving become classics of our time, the Harry Potter eBooks never fail to bring comfort and escapism. With their message of hope, belonging and the enduring power of truth and love, the story of the Boy Who Lived continues to delight generations of new readers.",
                Author = userJoanne,
                Publisher = publisherPottermore,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "128.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyFiction,
                    categoryChildrenFictionChildren
                }
            };

            Context.Books.Add(book128);

            var book129 = new Book
            {
                Title = "Harry Potter and the Order of the Phoenix",
                PageCount = 412,
                Price = 16.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 16.99m
                    }
                },
                ReleaseDate = new DateTime(2015, 3, 2),
                Description = "\\'You are sharing the Dark Lord\\'s thoughts and emotions. The Headmaster thinks it inadvisable for this to continue. He wishes me to teach you how to close your mind to the Dark Lord.\\'\r\n\r\nDark times have come to Hogwarts. After the Dementors\\' attack on his cousin Dudley, Harry Potter knows that Voldemort will stop at nothing to find him. There are many who deny the Dark Lord\\'s return, but Harry is not alone: a secret order gathers at Grimmauld Place to fight against the Dark forces. Harry must allow Professor Snape to teach him how to protect himself from Voldemort\\'s savage assaults on his mind. But they are growing stronger by the day and Harry is running out of time ...",
                Author = userJoanne,
                Publisher = publisherPottermore,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "129.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFictionChildren,
                    categoryChildrenFantasyFiction,
                    categoryChildrenThrillersMistery
                }
            };

            Context.Books.Add(book129);

            var book130 = new Book
            {
                Title = "Harry Potter and the Sorcerer\'s Stone",
                PageCount = 341,
                Price = 13.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 11.99m
                    },
                    new Price
                    {
                        Value = 13.99m
                    }
                },
                ReleaseDate = new DateTime(2015, 12, 4),
                Description = "Turning the envelope over, his hand trembling, Harry saw a purple wax seal bearing a coat of arms; a lion, an eagle, a badger and a snake surrounding a large letter \\'H\\'.\r\n\r\nHarry Potter has never even heard of Hogwarts when the letters start dropping on the doormat at number four, Privet Drive. Addressed in green ink on yellowish parchment with a purple seal, they are swiftly confiscated by his grisly aunt and uncle. Then, on Harry\\'s eleventh birthday, a great beetle-eyed giant of a man called Rubeus Hagrid bursts in with some astonishing news: Harry Potter is a wizard, and he has a place at Hogwarts School of Witchcraft and Wizardry. An incredible adventure is about to begin!\r\n\r\nHaving become classics of our time, the Harry Potter eBooks never fail to bring comfort and escapism. With their message of hope, belonging and the enduring power of truth and love, the story of the Boy Who Lived continues to delight generations of new readers.",
                Author = userJoanne,
                Publisher = publisherPottermore,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "130.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenThrillersMistery,
                    categoryChildrenFantasyFiction,
                    categoryChildrenFictionChildren
                }
            };

            Context.Books.Add(book130);

            var book131 = new Book
            {
                Title = "Fairy Tale",
                PageCount = 607,
                Price = 18.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 18.99m
                    }
                },
                ReleaseDate = new DateTime(2022, 1, 5),
                Description = "Legendary storyteller Stephen King goes into the deepest well of his imagination in this spellbinding novel about a seventeen-year-old boy who inherits the keys to a parallel world where good and evil are at war, and the stakes could not be higher-for that world or ours.\r\n\r\nCharlie Reade looks like a regular high school kid, great at baseball and football, a decent student. But he carries a heavy load. His mom was killed in a hit-and-run accident when he was seven, and grief drove his dad to drink. Charlie learned how to take care of himself-and his dad. When Charlie is seventeen, he meets a dog named Radar and her aging master, Howard Bowditch, a recluse in a big house at the top of a big hill, with a locked shed in the backyard. Sometimes strange sounds emerge from it.\r\n\r\nCharlie starts doing jobs for Mr. Bowditch and loses his heart to Radar. Then, when Bowditch dies, he leaves Charlie a cassette tape telling a story no one would believe. What Bowditch knows, and has kept secret all his long life, is that inside the shed is a portal to another world.",
                Author = userSteven,
                Publisher = publisherScribner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "131.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenThrillersMistery,
                    categoryChildrenFantasyFiction,
                    categoryChildrenFictionChildren
                }
            };

            Context.Books.Add(book131);

            var book132 = new Book
            {
                Title = "Billy Summers",
                PageCount = 527,
                Price = 17.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 17.99m
                    }
                },
                ReleaseDate = new DateTime(2011, 11, 24),
                Description = "Master storyteller Stephen King, whose \"restless imagination is a power that cannot be contained\" (The New York Times Book Review), presents an unforgettable and relentless #1 New York Times bestseller about a good guy in a bad job.\r\n\r\nChances are, if you\\'re a target of Billy Summers, two immutable truths apply: You\\'ll never even know what hit you, and you\\'re really getting what you deserve. He\\'s a killer for hire and the best in the business-but he\\'ll do the job only if the assignment is a truly bad person. But now, time is catching up with him, and Billy wants out. Before he can do that though, there\\'s one last hit, which promises a generous payday at the end of the line even as things don\\'t seem quite on the level here. Given that Billy is among the most talented snipers in the world, a decorated Iraq war vet, and a virtual Houdini when it comes to vanishing after the job is done, what could possibly go wrong? How about everything.\r\n\r\nPart war story and part love letter to small-town America and the people who live there, this spectacular thriller of luck, fate, and love will grip readers with its electrifying narrative, as a complex antihero with one last shot at redemption must avenge the crimes of an extraordinarily evil man. You won\\'t ever forget this stunning novel from master storyteller Stephen King…and you will never forget Billy.",
                Author = userSteven,
                Publisher = publisherScribner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "132.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyFiction,
                    categoryChildrenFictionChildren
                }
            };

            Context.Books.Add(book132);

            var book133 = new Book
            {
                Title = "The Dark Tower I: The Gunslinger",
                PageCount = 284,
                Price = 12.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 11.99m
                    },
                    new Price
                    {
                        Value = 12.99m
                    }
                },
                ReleaseDate = new DateTime(2016, 1, 4),
                Description = "\"An impressive work of mythic magnitude that may turn out to be Stephen King\\'s greatest literary achievement\" (The Atlanta Journal-Constitution), The Gunslinger is the first volume in the epic Dark Tower Series.\r\n\r\nA #1 national bestseller, The Gunslinger introduces readers to one of Stephen King\\'s most powerful creations, Roland of Gilead: The Last Gunslinger. He is a haunting figure, a loner on a spellbinding journey into good and evil. In his desolate world, which mirrors our own in frightening ways, Roland tracks The Man in Black, encounters an enticing woman named Alice, and begins a friendship with the boy from New York named Jake.\r\n\r\nInspired in part by the Robert Browning narrative poem, \"Childe Roland to the Dark Tower Came,\" The Gunslinger is \"a compelling whirlpool of a story that draws one irretrievable to its center\" (Milwaukee Sentinel). It is \"brilliant and fresh…and will leave you panting for more\" (Booklist).",
                Author = userSteven,
                Publisher = publisherScribner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "133.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyFiction,
                    categoryChildrenThrillersMistery
                }
            };

            Context.Books.Add(book133);

            var book134 = new Book
            {
                Title = "The Institute",
                PageCount = 560,
                Price = 18.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 14.99m
                    },
                    new Price
                    {
                        Value = 18.99m
                    }
                },
                ReleaseDate = new DateTime(2019, 8, 6),
                Description = "In the middle of the night, in a house on a quiet street in suburban Minneapolis, intruders silently murder Luke Ellis\\'s parents and load him into a black SUV. The operation takes less than two minutes. Luke will wake up at The Institute, in a room that looks just like his own, except there\\'s no window. And outside his door are other doors, behind which are other kids with special talents-telekinesis and telepathy-who got to this place the same way Luke did: Kalisha, Nick, George, Iris, and ten-year-old Avery Dixon. They are all in Front Half. Others, Luke learns, graduated to Back Half, \"like the roach motel,\" Kalisha says. \"You check in, but you don\\'t check out.\"\r\n\r\nIn this most sinister of institutions, the director, Mrs. Sigsby, and her staff are ruthlessly dedicated to extracting from these children the force of their extranormal gifts. There are no scruples here. If you go along, you get tokens for the vending machines. If you don\\'t, punishment is brutal. As each new victim disappears to Back Half, Luke becomes more and more desperate to get out and get help. But no one has ever escaped from the Institute.\r\n\r\nAs psychically terrifying as Firestarter, and with the spectacular kid power of It, The Institute is \"first-rate entertainment that has something important to say. We all need to listen\" (The Washington Post).",
                Author = userSteven,
                Publisher = publisherScribner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "134.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenThrillersMistery,
                    categoryChildrenHorrorFiction,
                    categoryChildrenFantasyFiction
                }
            };

            Context.Books.Add(book134);

            var book135 = new Book
            {
                Title = "The Shining",
                PageCount = 674,
                Price = 25.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 24.99m
                    },
                    new Price
                    {
                        Value = 25.00m
                    }
                },
                ReleaseDate = new DateTime(2008, 1, 24),
                Description = "Jack Torrance\'s new job at the Overlook Hotel is the perfect chance for a fresh start. As the off-season caretaker at the atmospheric old hotel, he\'ll have plenty of time to spend reconnecting with his family and working on his writing. But as the harsh winter weather sets in, the idyllic location feels ever more remote . . . and more sinister. And the only one to notice the strange and terrible forces gathering around the Overlook is Danny Torrance, a uniquely gifted five-year-old.",
                Author = userSteven,
                Publisher = publisherScribner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "135.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHorrorFiction,
                    categoryChildrenDetectiveMistery
                }
            };

            Context.Books.Add(book135);

            var book136 = new Book
            {
                Title = "Gwendy\'s Final Task",
                PageCount = 287,
                Price = 13.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 11.99m
                    },
                    new Price
                    {
                        Value = 13.99m
                    }
                },
                ReleaseDate = new DateTime(2022, 5, 31),
                Description = "The final book in the New York Times bestselling Gwendy\\'s Button Box trilogy from Stephen King and Richard Chizmar.\r\n\r\nWhen Gwendy Peterson was twelve, a mysterious stranger named Richard Farris gave her a mysterious box for safekeeping. It offered treats and vintage coins, but it was dangerous. Pushing any of its eight colored buttons promised death and destruction. Years later, the button box reentered Gwendy\\'s life. A successful novelist and a rising political star, she was once again forced to deal with the temptation the box represented. Now, malignant forces seek to possess the button box, and it is up to Senator Gwendy Peterson to keep it from them at all costs. But where can one hide something from such powerful entities?\r\n\r\nIn Gwendy\\'s Final Task, master storytellers Stephen King and Richard Chizmar take us on a journey from Castle Rock to another famous cursed Maine city to the MF-1 space station, where Gwendy must execute a secret mission to save the world. And, maybe, all worlds.",
                Author = userSteven,
                Publisher = publisherScribner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "136.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyFiction,
                }
            };

            Context.Books.Add(book136);

            var book137 = new Book
            {
                Title = "The Outsider",
                PageCount = 655,
                Price = 15.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 11.99m
                    },
                    new Price
                    {
                        Value = 15.99m
                    }
                },
                ReleaseDate = new DateTime(2018, 2, 25),
                Description = "Evil has many faces…maybe even yours in this #1 New York Times bestseller from master storyteller Stephen King.\r\n\r\nAn eleven-year-old boy\\'s violated corpse is discovered in a town park. Eyewitnesses and fingerprints point unmistakably to one of Flint City\\'s most popular citizens-Terry Maitland, Little League coach, English teacher, husband, and father of two girls. Detective Ralph Anderson, whose son Maitland once coached, orders a quick and very public arrest. Maitland has an alibi, but Anderson and the district attorney soon have DNA evidence to go with the fingerprints and witnesses. Their case seems ironclad.\r\n\r\nAs the investigation expands and horrifying details begin to emerge, King\\'s story kicks into high gear, generating strong tension and almost unbearable suspense. Terry Maitland seems like a nice guy, but is he wearing another face? When the answer comes, it will shock you as only Stephen King can.",
                Author = userSteven,
                Publisher = publisherScribner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "137.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyFiction
                }
            };

            Context.Books.Add(book137);

            var book138 = new Book
            {
                Title = "Mr. Mercedes",
                PageCount = 559,
                Price = 26.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 24.99m
                    },
                    new Price
                    {
                        Value = 26.99m
                    }
                },
                ReleaseDate = new DateTime(2014, 3, 1),
                Description = "#1 New York Times bestseller! In a high-suspense race against time, three of the most unlikely heroes Stephen King has ever created try to stop a lone killer from blowing up thousands. \"Mr. Mercedes is a rich, resonant, exceptionally readable accomplishment by a man who can write in whatever genre he chooses\" (The Washington Post).\r\n\r\nThe stolen Mercedes emerges from the pre-dawn fog and plows through a crowd of men and women on line for a job fair in a distressed American city. Then the lone driver backs up, charges again, and speeds off, leaving eight dead and more wounded. The case goes unsolved and ex-cop Bill Hodges is out of hope when he gets a letter from a man who loved the feel of death under the Mercedes\\'s wheels…\r\n\r\nBrady Hartsfield wants that rush again, but this time he\\'s going big, with an attack that would take down thousands-unless Hodges and two new unusual allies he picks up along the way can throw a wrench in Hartsfield\\'s diabolical plans. Stephen King takes off on a \"nerve-shredding, pulse-pounding race against time\" (Fort Worth Star-Telegram) with this acclaimed #1 bestselling thriller.",
                Author = userSteven,
                Publisher = publisherScribner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "138.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyFiction,
                    categoryChildrenThrillersMistery
                }
            };

            Context.Books.Add(book138);

            var book139 = new Book
            {
                Title = "\'Salem\'s Lot",
                PageCount = 668,
                Price = 27.00m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 24.99m
                    },
                    new Price
                    {
                        Value = 27.00m
                    }
                },
                ReleaseDate = new DateTime(2008, 6, 1),
                Description = "Ben Mears has returned to Jerusalem\\'s Lot in hopes that exploring the history of the Marsten House, an old mansion long the subject of rumor and speculation, will help him cast out his personal devils and provide inspiration for his new book.\r\n\r\nBut when two young boys venture into the woods, and only one returns alive, Mears begins to realize that something sinister is at work.\r\n\r\nIn fact, his hometown is under siege from forces of darkness far beyond his imagination. And only he, with a small group of allies, can hope to contain the evil that is growing within the borders of this small New England town.\r\n\r\nWith this, his second novel, Stephen King established himself as an indisputable master of American horror, able to transform the old conceits of the genre into something fresh and all the more frightening for taking place in a familiar, idyllic locale.",
                Author = userSteven,
                Publisher = publisherScribner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "139.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenFantasyFiction,
                    categoryChildrenThrillersMistery
                }
            };

            Context.Books.Add(book139);

            var book140 = new Book
            {
                Title = "It",
                PageCount = 1181,
                Price = 24.99m,
                Prices = new List<Price> 
                {
                    new Price
                    {
                        Value = 21.99m
                    },
                    new Price
                    {
                        Value = 24.99m
                    }
                },
                ReleaseDate = new DateTime(2016, 7, 3),
                Description = "Stephen King\\'s terrifying, classic #1 New York Times bestseller, \"a landmark in American literature\" (Chicago Sun-Times)-about seven adults who return to their hometown to confront a nightmare they had first stumbled on as teenagers…an evil without a name: It.\r\n\r\nWelcome to Derry, Maine. It\\'s a small city, a place as hauntingly familiar as your own hometown. Only in Derry the haunting is real.\r\n\r\nThey were seven teenagers when they first stumbled upon the horror. Now they are grown-up men and women who have gone out into the big world to gain success and happiness. But the promise they made twenty-eight years ago calls them reunite in the same place where, as teenagers, they battled an evil creature that preyed on the city\\'s children. Now, children are being murdered again and their repressed memories of that terrifying summer return as they prepare to once again battle the monster lurking in Derry\\'s sewers.",
                Author = userSteven,
                Publisher = publisherScribner,
                Image = new Image
                {
                    Alt = "Book Image",
                    Src = "140.jpg"
                },
                Categories = new List<Category>
                {
                    categoryChildrenHorrorFiction,
                    categoryChildrenThrillersMistery
                }
            };

            Context.Books.Add(book140);

            #endregion

            #region Role Use Cases Seed
                var uc1 = new RoleUseCase
                {
                    UseCaseId = 1,
                    Role = roleAdmin,
                };

                var uc2 = new RoleUseCase
                {
                    UseCaseId = 2,
                    Role = roleAdmin,
                };

                var uc3 = new RoleUseCase
                {
                    UseCaseId = 3,
                    Role = roleAdmin,
                };

                var uc4 = new RoleUseCase
                {
                    UseCaseId = 4,
                    Role = roleAdmin,
                };

                var uc5 = new RoleUseCase
                {
                    UseCaseId = 5,
                    Role = roleAdmin,
                };

                var uc6 = new RoleUseCase
                {
                    UseCaseId = 6,
                    Role = roleAdmin,
                };

                var uc7 = new RoleUseCase
                {
                    UseCaseId = 7,
                    Role = roleAdmin,
                };

                var uc8 = new RoleUseCase
                {
                    UseCaseId = 8,
                    Role = roleAdmin,
                };

                var uc9 = new RoleUseCase
                {
                    UseCaseId = 9,
                    Role = roleAdmin,
                };

                var uc10 = new RoleUseCase
                {
                    UseCaseId = 10,
                    Role = roleAdmin,
                };

                var uc11 = new RoleUseCase
                {
                    UseCaseId = 11,
                    Role = roleAdmin,
                };

                var uc12 = new RoleUseCase
                {
                    UseCaseId = 12,
                    Role = roleAdmin,
                };

                var uc13 = new RoleUseCase
                {
                    UseCaseId = 13,
                    Role = roleAdmin,
                };

                var uc14 = new RoleUseCase
                {
                    UseCaseId = 14,
                    Role = roleAdmin,
                };

                var uc15 = new RoleUseCase
                {
                    UseCaseId = 15,
                    Role = roleAdmin,
                };

                var uc16 = new RoleUseCase
                {
                    UseCaseId = 16,
                    Role = roleAdmin,
                };

                var uc17 = new RoleUseCase
                {
                    UseCaseId = 17,
                    Role = roleAdmin,
                };

                var uc18 = new RoleUseCase
                {
                    UseCaseId = 18,
                    Role = roleAdmin,
                };

                var uc19 = new RoleUseCase
                {
                    UseCaseId = 19,
                    Role = roleAdmin,
                };

                var uc20 = new RoleUseCase
                {
                    UseCaseId = 20,
                    Role = roleAdmin,
                };

                var uc21 = new RoleUseCase
                {
                    UseCaseId = 21,
                    Role = roleAdmin,
                };

                var uc22 = new RoleUseCase
                {
                    UseCaseId = 22,
                    Role = roleAdmin,
                };

                var uc23 = new RoleUseCase
                {
                    UseCaseId = 23,
                    Role = roleAdmin,
                };

                var uc24 = new RoleUseCase
                {
                    UseCaseId = 24,
                    Role = roleAdmin,
                };

                var uc25 = new RoleUseCase
                {
                    UseCaseId = 25,
                    Role = roleAdmin,
                };

                var uc26 = new RoleUseCase
                {
                    UseCaseId = 26,
                    Role = roleAdmin,
                };

                var uc27 = new RoleUseCase
                {
                    UseCaseId = 27,
                    Role = roleAdmin,
                };

                var uc28 = new RoleUseCase
                {
                    UseCaseId = 28,
                    Role = roleAdmin,
                };

                var uc29 = new RoleUseCase
                {
                    UseCaseId = 29,
                    Role = roleAdmin,
                };

                var uc30 = new RoleUseCase
                {
                    UseCaseId = 30,
                    Role = roleAdmin,
                };

                var uc31 = new RoleUseCase
                {
                    UseCaseId = 31,
                    Role = roleAdmin,
                };

                var uc32 = new RoleUseCase
                {
                    UseCaseId = 32,
                    Role = roleAdmin,
                };

                var uc33 = new RoleUseCase
                {
                    UseCaseId = 33,
                    Role = roleAdmin,
                };

                var uc34 = new RoleUseCase
                {
                    UseCaseId = 37,
                    Role = roleAdmin,
                };

                var uc35 = new RoleUseCase
                {
                    UseCaseId = 38,
                    Role = roleAdmin,
                };

                var uc36 = new RoleUseCase
                {
                    UseCaseId = 39,
                    Role = roleAdmin,
                };

                var uc37 = new RoleUseCase
                {
                    UseCaseId = 40,
                    Role = roleAdmin,
                };

                var uc38 = new RoleUseCase
                {
                    UseCaseId = 41,
                    Role = roleAdmin,
                };

                var uc39 = new RoleUseCase
                {
                    UseCaseId = 42,
                    Role = roleAdmin,
                };

                var uc40 = new RoleUseCase
                {
                    UseCaseId = 43,
                    Role = roleAdmin,
                };

                var uc41 = new RoleUseCase
                {
                    UseCaseId = 44,
                    Role = roleAdmin,
                };

                var uc42 = new RoleUseCase
                {
                    UseCaseId = 49,
                    Role = roleAdmin,
                };

                var uc43 = new RoleUseCase
                {
                    UseCaseId = 50,
                    Role = roleAdmin,
                };

                var uc44 = new RoleUseCase
                {
                    UseCaseId = 51,
                    Role = roleAdmin,
                };

                var uc45 = new RoleUseCase
                {
                    UseCaseId = 52,
                    Role = roleAdmin,
                };

                var uc46 = new RoleUseCase
                {
                    UseCaseId = 53,
                    Role = roleAdmin,
                };

                var uc47 = new RoleUseCase
                {
                    UseCaseId = 54,
                    Role = roleAdmin,
                };

                var uc48 = new RoleUseCase
                {
                    UseCaseId = 55,
                    Role = roleAdmin,
                };

                var uc49 = new RoleUseCase
                {
                    UseCaseId = 56,
                    Role = roleAdmin,
                };

                var uc50 = new RoleUseCase
                {
                    UseCaseId = 57,
                    Role = roleAdmin,
                };

                var uc51 = new RoleUseCase
                {
                    UseCaseId = 58,
                    Role = roleAdmin,
                };

                var uc52 = new RoleUseCase
                {
                    UseCaseId = 59,
                    Role = roleAdmin,
                };

                var uc53 = new RoleUseCase
                {
                    UseCaseId = 60,
                    Role = roleAdmin,
                };

                var uc54 = new RoleUseCase
                {
                    UseCaseId = 61,
                    Role = roleAdmin,
                };

                var uc55 = new RoleUseCase
                {
                    UseCaseId = 62,
                    Role = roleAdmin,
                };

                var uc56 = new RoleUseCase
                {
                    UseCaseId = 63,
                    Role = roleAdmin,
                };

                var uc57 = new RoleUseCase
                {
                    UseCaseId = 64,
                    Role = roleAdmin,
                };

                var uc58 = new RoleUseCase
                {
                    UseCaseId = 65,
                    Role = roleAdmin,
                };

                var uc59 = new RoleUseCase
                {
                    UseCaseId = 66,
                    Role = roleAdmin,
                };

                var uc60 = new RoleUseCase
                {
                    UseCaseId = 67,
                    Role = roleAdmin,
                };

            Context.RoleUseCases.Add(uc1);
            Context.RoleUseCases.Add(uc2);
            Context.RoleUseCases.Add(uc3);
            Context.RoleUseCases.Add(uc4);
            Context.RoleUseCases.Add(uc5);
            Context.RoleUseCases.Add(uc6);
            Context.RoleUseCases.Add(uc7);
            Context.RoleUseCases.Add(uc8);
            Context.RoleUseCases.Add(uc9);
            Context.RoleUseCases.Add(uc10);
            Context.RoleUseCases.Add(uc11);
            Context.RoleUseCases.Add(uc12);
            Context.RoleUseCases.Add(uc13);
            Context.RoleUseCases.Add(uc14);
            Context.RoleUseCases.Add(uc15);
            Context.RoleUseCases.Add(uc16);
            Context.RoleUseCases.Add(uc17);
            Context.RoleUseCases.Add(uc18);
            Context.RoleUseCases.Add(uc19);
            Context.RoleUseCases.Add(uc20);
            Context.RoleUseCases.Add(uc21);
            Context.RoleUseCases.Add(uc22);
            Context.RoleUseCases.Add(uc23);
            Context.RoleUseCases.Add(uc24);
            Context.RoleUseCases.Add(uc25);
            Context.RoleUseCases.Add(uc26);
            Context.RoleUseCases.Add(uc27);
            Context.RoleUseCases.Add(uc28);
            Context.RoleUseCases.Add(uc29);
            Context.RoleUseCases.Add(uc30);
            Context.RoleUseCases.Add(uc31);
            Context.RoleUseCases.Add(uc32);
            Context.RoleUseCases.Add(uc33);
            Context.RoleUseCases.Add(uc34);
            Context.RoleUseCases.Add(uc35);
            Context.RoleUseCases.Add(uc36);
            Context.RoleUseCases.Add(uc37);
            Context.RoleUseCases.Add(uc38);
            Context.RoleUseCases.Add(uc39);
            Context.RoleUseCases.Add(uc40);
            Context.RoleUseCases.Add(uc41);
            Context.RoleUseCases.Add(uc42);
            Context.RoleUseCases.Add(uc43);
            Context.RoleUseCases.Add(uc44);
            Context.RoleUseCases.Add(uc45);
            Context.RoleUseCases.Add(uc46);
            Context.RoleUseCases.Add(uc47);
            Context.RoleUseCases.Add(uc48);
            Context.RoleUseCases.Add(uc49);
            Context.RoleUseCases.Add(uc50);
            Context.RoleUseCases.Add(uc51);
            Context.RoleUseCases.Add(uc52);
            Context.RoleUseCases.Add(uc53);
            Context.RoleUseCases.Add(uc54);
            Context.RoleUseCases.Add(uc55);
            Context.RoleUseCases.Add(uc56);
            Context.RoleUseCases.Add(uc57);
            Context.RoleUseCases.Add(uc58);
            Context.RoleUseCases.Add(uc59);
            Context.RoleUseCases.Add(uc60);
            #endregion

            Context.SaveChanges();
        }
    }
}
