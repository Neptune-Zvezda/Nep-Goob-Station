// SPDX-FileCopyrightText: 2024 Tayrtahn <tayrtahn@gmail.com>
// SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.Serialization;

namespace Content.Shared.Guidebook;

/// <summary>
/// Raised by the client on GuidebookDataSystem Initialize to request a
/// full set of guidebook data from the server.
/// </summary>
[Serializable, NetSerializable]
public sealed class RequestGuidebookDataEvent : EntityEventArgs { }

/// <summary>
/// Raised by the server at a specific client in response to <see cref="RequestGuidebookDataEvent"/>.
/// Also raised by the server at ALL clients when prototype data is hot-reloaded.
/// </summary>
[Serializable, NetSerializable]
public sealed class UpdateGuidebookDataEvent : EntityEventArgs
{
    public GuidebookData Data;

    public UpdateGuidebookDataEvent(GuidebookData data)
    {
        Data = data;
    }
}