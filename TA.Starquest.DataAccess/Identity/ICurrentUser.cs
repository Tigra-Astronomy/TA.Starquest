// This file is part of the TA.Starquest project
// Copyright © 2015-2024 Timtek Systems Limited, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: ICurrentUser.cs  Last modified: 2024-2-25@18:32 by Tim

namespace TA.Starquest.DataAccess.Identity;

/// <summary>
///     A service for accessing details of the current user. In the case of a web application, the 'current' user
///     would typically be the user making the request.
/// </summary>
/// <remarks>
///     Note that a user may be 'current' without necessarily being logged in. The presence of a 'current user'
///     simply means the user has been identified and is no guarantee that they have been authenticated.
///     <see cref="IsAuthenticated" />.
/// </remarks>
public interface ICurrentUser
{
    /// <summary>
    ///     Gets the display name of the user.
    /// </summary>
    /// <value>The display name.</value>
    string DisplayName { get; }

    /// <summary>
    ///     Gets the login name of the user. This is typically what the user would enter in the login screen, but may be
    ///     something different.
    /// </summary>
    /// <value>The name of the login.</value>
    string LoginName { get; }

    /// <summary>
    ///     Gets the unique identifier of the user. Typically this is used as the Row ID in whatever store is used to persist
    ///     the user's details.
    /// </summary>
    /// <value>The unique identifier.</value>
    string UniqueId { get; }

    /// <summary>
    ///     Gets a value indicating whether the user has been authenticated.
    /// </summary>
    /// <value><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</value>
    bool IsAuthenticated { get; }
}