# Pre-Release Pull Request

## Purpose

- Get and document approval for a new release of a packages in the dotnet-general repository

## Release Version

- *vX.X.X*

## Tasks and Assertions

### Pre-Review

*This section should be completed by a developer, and is intended to prepare the new release for review.*

Completed by: ___________

##### Tasks

- [ ] Fill in the Release Version above and name this pull request "Pre-Release - vX.X.X" to match the release version
- [ ] The package version is updated to an appropriate production version syntax vx.x.x with no non-production suffix
- [ ] Publish the newly built package using the publishing profile included in the project
- [ ] Document an appropriate testing strategy / checklist
- [ ] Complete the testing checklist
- [ ] Create issues for any bugs found in testing
- [ ] Triage all discovered issues and address high priority / risk bugs
- [ ] Check that prioritized issues have been resolved
- [ ] Identify reviewer(s) and communicate changes to them
- [ ] Hand off to Peer Reviewer(s)

##### Assertions

- [ ] The Release Version has been updated in this pull request above
- [ ] All tests are passing
- [ ] The software version and release versions match
- [ ] The release notes are up to date and reflect the changes included in this release
- [ ] The UAT Documentation has been prepared for the reviewer(s)
- [ ] All developers that have completed this section have been documented above

### PRPR

*This section should be completed by the reviewer, and is intended to track review progress.*

Completed by: ___________

##### Tasks

- [ ] Determine risk level
- [ ] Perform PRPR
- [ ] Document your Peer Review in comment below

##### Assertions

- [ ] The release has been documented appropriately
- [ ] All reviewers have been documented above
- [ ] The risk level for this release has been documented in this pull request
- [ ] All necessary reviewers have added their Peer Review Attestation below

### Post-Review Tasks

*This section should be completed by a developer, and is intended to ensure that the release is promoted and properly documented.*

Completed by: ___________

##### Tasks

- [ ] Merge into master branch and promote released code base
- [ ] Tag the release in the master branch
- [ ] Merge master into develop to make sure warm changes are propagated
- [ ] As appropriate, remove prerelease versions of the released package from S:\PRM\packages

##### Assertions

- [ ] All tasks have been completed
- [ ] All assertions have been met
- [ ] All developers that have completed this section have been documented above
