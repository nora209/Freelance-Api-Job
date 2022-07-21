# Layering Application using .Net Core API Guide

## Purpose:
This demo has been made to demonstrate how to layer your application using Web API.

## Approach:
We are going to layer the application into 3 layers:
- Presentation Layer: which contains all the controllers and their related logic. Like when to return 404, 400 and so on.
- Business Layer: which contains all the business logic. Like mapping Database models to business models.
- Data Access Layer: which contains the context, the database models, repositories and unit of work.

## Authors
Special Thanks to:
  - [@Nora](https://github.com/nora209)
