# Joni Remote Manifest Gate

This repository currently serves the `stable` test manifest for Joni Bootstrap Launcher v0.1.7.

## Gate sequence

1. Fetch `manifests/stable.json` over HTTPS.
2. Verify the expected SHA-256 of the manifest before trusting its contents.
3. Validate product, assistant, channel, minimum launcher version and Windows x64 profile.
4. Download the harmless probe component from the approved raw GitHub source.
5. Test interrupted download / resume or safe full restart fallback.
6. Verify component size and SHA-256.
7. Stage, install and verify health.
8. Commit local state only after all checks pass.

## Current test artifact

`artifacts/joni-remote-probe-v1.txt` contains no executable code and requires no administrator privileges.

## Next security gate

Replace manual manifest SHA pinning with a cryptographic signed-manifest trust chain using a public verification key embedded in Joni Launcher.
