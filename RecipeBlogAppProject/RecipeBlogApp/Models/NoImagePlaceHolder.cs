﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBlogApp.Models
{
    public class NoImagePlaceHolder
    {
        public static readonly string Placeholder = "/9j/4AAQSkZJRgABAQEAkACQAAD/2wBDAAIBAQIBAQICAgICAgICAwUDAwMDAwYEBAMFBwYHBwcGBwcICQsJCAgKCAcHCg0KCgsMDAwMBwkODw0MDgsMDAz/2wBDAQICAgMDAwYDAwYMCAcIDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAz/wAARCAFMAfQDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD9/KKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKK/Mf/AIKIf8Fovij+yT/wWm+B37OXhzQfAN74I+Ji6OdUvtSsbuTVYPtmoT20vkyR3KRLhIlK7omwxOcjgEPfrU6C+Kb5V66v9Al7tKdZ7QXM/TRfqfpxRRRQAUV+Y3/BSj/gtf8AGD9jP/grp8GfgH4S+Eun+KvB3xASwa8vJbe5fU9S+0XTwy/YZEkWFPs6KHfzEk77jGuGr9OacVzUlWWzcl84uzCfu1PZPeyfylqgooopAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUV5j+2n8b9b/AGav2SPiR8QPDfhyXxdr3g3w7e6vYaPGGJv5oYWdUIQFiuRkhRuwDjmvmL/ggB/wVB+Iv/BVr9kLWPHnxH8EaV4T1LS9el0q1vNHgng0vWoljR98CTySSAxsxRzvZSRwQdyq6a9o5qP2Em/Ruy/EJ+5GMn9ptL1Sv+R910UUUgCiiigAooooAKKKKACiiigAoooo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gAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooA//9k=";
    }
}