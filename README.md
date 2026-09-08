# OmegaSolider

Protocol Buffers contracts and models for the OmegaSolider and FireflyExpert message specifications.

## Messages

### `OmegaSolider` (Input)
- `soldier_id` (string): Unique identifier for the soldier.
- `codename` (string): Operative callsign.
- `rank_level` (int32): Tactical rank level.
- `bravery_points` (int32): Bravery score.
- `favorite_snack` (string): Operative's preferred field ration.

### `FireflyExpert` (Output)
- `soldier_id` (string): Preserved identifier from OmegaSolider.
- `codename` (string): Preserved codename.
- `rank_level` (int32): Preserved rank.
- `glow_intensity` (int32): Calculated luminescence / power level.
- `expertise` (string): Field specialization.
- `comedic_buff` (string): Humorous enhancement applied externally or default unbuffed state.
- `secret_mission` (string): Designated operational mission.
- `processed_at_unix_ms` (int64): Millisecond UTC timestamp when transformed.

## Build & Pack

```bash
dotnet build
dotnet pack -c Release -o ./artifacts
```
