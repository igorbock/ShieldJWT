﻿global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using System.Security.Cryptography;
global using System.Text.RegularExpressions;
global using System.Net.Mime;

global using ShieldJWT.Services;
global using ShieldJWT.Context;
global using ShieldJWT.Exceptions;
global using ShieldJWT.Extensions;
global using ShieldJWT.Middlewares;
global using ShieldJWT.BackgroundServices;
global using ShieldJWT.Filters;

global using ShieldJWTLib.Interfaces;
global using ShieldJWTLib.Models;
global using ShieldJWTLib.Abstract;
global using ShieldJWTLib.Models.DTO;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.AspNetCore.Mvc.Filters;

global using Scalar.AspNetCore;

global using MimeKit;

global using MailKit.Net.Smtp;