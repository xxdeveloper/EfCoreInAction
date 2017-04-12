﻿// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Chapter07Listings.EfClasses;

namespace Test.Chapter07Listings.EFCode.Configurations
{
    public static class AttendeeConfig
    {
        public static void Configure
            (this EntityTypeBuilder<Attendee> entity)
        {
            entity.HasOne(p => p.Ticket) //#A
                .WithOne(p => p.Attendee)
                .HasForeignKey<Attendee>
                    (p => p.TicketId); //#B

            //entity.HasOne(p => p.Required) //#C
            //    .WithOne()
            //    .HasForeignKey<Attendee>(
            //        "RequiredTrackId") //#D
            //    .IsRequired(); //#E
        }
        /*******************************************************************
        #A This sets up the one-to-one navigational relationship, Ticket, which has a foreign key defined in the Attendee class
        #B Here I specify the property that is the foreign key. Note how I need to provide the class type, as the foreign key could be in the principal or dependent entity class
        #C This sets up the one-to-one navigational relationship, Required, which does not have a foreign key defined for it
        #D I use the HasForeignKey<T> method that takes a string, because it is a shadow property and can only be referred to via a name. 
        #E In this case I use IsRequired to say the foreign key should not be nullable
         * ********************************************************************/
    }
}