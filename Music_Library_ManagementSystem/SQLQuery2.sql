select * from  Customer Customer
                     join  CustomerRentData customerrentdat on Customer.Id = customerrentdat.CustomerId

                     join  RentData renddata  on customerrentdat.CustomerId = renddata.CustomerId

                     join  Mediadata Mediadata on customerrentdat.MediaId = Mediadata.Id 
