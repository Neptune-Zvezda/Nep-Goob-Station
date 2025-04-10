// SPDX-FileCopyrightText: 2024 deltanedas <39013340+deltanedas@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 deltanedas <@deltanedas:kde.org>
// SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Server.Antag.Components;
using Content.Server.GameTicking.Rules;

namespace Content.Server.Antag;

public sealed class AntagRandomSpawnSystem : GameRuleSystem<AntagRandomSpawnComponent>
{
    [Dependency] private readonly SharedTransformSystem _transform = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<AntagRandomSpawnComponent, AntagSelectLocationEvent>(OnSelectLocation);
    }

    private void OnSelectLocation(Entity<AntagRandomSpawnComponent> ent, ref AntagSelectLocationEvent args)
    {
        if (TryFindRandomTile(out _, out _, out _, out var coords))
            args.Coordinates.Add(_transform.ToMapCoordinates(coords));
    }
}