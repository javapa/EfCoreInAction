﻿// Copyright (c) 2016 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Test.Chapter09Listings.EfCode;

namespace Test.Chapter09Listings.EfClasses
{
    public class NotifyEntity : NotificationEntity
    {
        private int _id;             //#A
        private string _myString;    //#A
        private NotifyOne _oneToOne; //#A

        public int Id
        {
            get => _id;
            set => SetWithNotify(value, ref _id); //#B
        }

        public string MyString
        {
            get => _myString;
            set => SetWithNotify(value, ref _myString); //#B
        }

        public NotifyOne OneToOne
        {
            get => _oneToOne;
            set => SetWithNotify(value, ref _oneToOne); //#B
        }

        public ICollection<NotifyMany> 
            Many { get; } //#C
            = new ObservableHashSet<NotifyMany>(); //#D
    }
    /**************************************************************
    #A Each non-collection property must have a backing field
    #B If a non-collection property is changed we need to raise a PropertyChanged event, which we do via the inherited method SetWithNotify
    #C Any collection navigational property has to be a Obvervable collection, so we need to predefine that Obvervable collection
    #D We can use any Obvervable collection, but for performance reasons EF Core prefers ObservableHashSet<T>
     * **************************************************************/
}