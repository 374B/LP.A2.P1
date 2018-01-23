The solution should work out of the box.

There is an in-memory database with some fake seed data.

When API is started it should launch the swagger UI, which provides both API documentation and a test harness. If it does not launch, it can be accessed at /swagger

The focus was on demonstrating a variety of concepts rather than focusing on one area in particular.

Not all of the functionality is implemented, however it should hopefully be clear how the missing functionality fits into the current structures and patterns

Example:
- Use the student and subject endpoints to find student/subject ids
- Use the subject/enroll endpoint to enroll a student in a subject
- If you try to enroll the student in the same subject again, you should see a domain validation error. This has gone through the "SubjectEnrollmentSpec"

Domain:
- The domain does not consider the fact that a subject would have multiple sessions (and that a lecture should live under a subject's session)
(This is what the SubjectSession object was intended for)

API:
- Should be using response specific DTO classes to support extension
- Paging has not been implemented

-Data
- There are no foreign keys or related entities
- Query performance/optimization has not been considered at all
- Because of the way the fake data is generated it is possible for the seed data to be invalid for the domain

Tests:
- There are a limited number of tests to demonstrate concepts, not completeness.
- The code has been written in such a way that it is easy to unit test

Misc
- There is no logging
- Error handling is minimal
