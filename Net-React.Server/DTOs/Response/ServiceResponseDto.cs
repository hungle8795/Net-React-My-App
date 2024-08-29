﻿using System;
namespace backend.Models;

public class ServiceResponseDto<T>
{
	public T? Data { get; set; }
	public bool IsSuccess { get; set; } = true;
	public string Message { get; set; } = string.Empty;
}