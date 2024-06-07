﻿using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Commands;

namespace fithub_backend.ProductsManagement.Domain.Services;

public interface ICardioProductCommandService
{
    Task<CardioProduct> Handle(CreateCardioProductCommand command);
}