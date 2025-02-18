using System.Domain.Entities;
using System.Text;
using FluentValidation;

namespace System.Domain.Validations;

public class CustomerValidation : AbstractValidator<Customer>
{
    private int minimumNumber = 2;
    private int maximumNumber = 255;

    private int cpfSize = 11;

    private int cnpjSize = 14;
    public CustomerValidation()
    {
        RuleFor(customer => customer.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Name field cannot be empty.")
            .Length(minimumNumber, maximumNumber)
            .WithMessage("Invalid name, must have a minimum of 2 characters and a maximum of 50 characters.");

        RuleFor(customer => customer.CPF)
            .Cascade(CascadeMode.Stop)
            .Must(cpf => VerifySize(cpfSize, cpf))
            .WithMessage("Invalid CPF, check that all 11 characters are filled in correctly.")
            .Must(cpf => IsCpf(cpf))
            .WithMessage("Invalid CPF, enter your CPF again.");

        RuleFor(customer => customer.CNPJ)
            .Cascade(CascadeMode.Stop)
            .Must(cnpj => VerifySize(cnpjSize, cnpj))
            .WithMessage("Invalid CNPJ, check that all 14 characters are filled in correctly.")
            .Must(cnpj => IsCnpj(cnpj))
            .WithMessage("Invalid CNPJ, enter your CNPJ again.");
    }

    public static bool VerifySize(int desiredSize, string obj)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in obj)
        {
            if (c >= '0' && c <= '9')
            {
                sb.Append(c);
            }
        }

        var size = sb.ToString().Length;

        return size == desiredSize 
            ? true 
            : false;
    }

    public static bool IsCnpj(string cnpj)
    {
        var firstMultiplier = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        var secondMultiplier = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        int sum;
        int remainder;
        string verificationDigits;
        string cleanedCnpj;

        cnpj = cnpj.Trim();
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

        if (cnpj.Length != 14)
        {
            return false;
        }

        cleanedCnpj = cnpj.Substring(0, 12);
        sum = 0;

        for (int i = 0; i < 12; i++)
        {
            sum += int.Parse(cleanedCnpj[i].ToString()) * firstMultiplier[i];
        }

        remainder = sum % 11;

        if (remainder < 2)
        {
            remainder = 0;
        }
        else
        {
            remainder = 11 - remainder;
        }

        verificationDigits = remainder.ToString();
        cleanedCnpj = cleanedCnpj + verificationDigits;
        sum = 0;

        for (int i = 0; i < 13; i++)
        {
            sum += int.Parse(cleanedCnpj[i].ToString()) * secondMultiplier[i];
        }

        remainder = sum % 11;

        if (remainder < 2)
        {
            remainder = 0;
        }
        else
        {
            remainder = 11 - remainder;
        }

        verificationDigits = verificationDigits + remainder.ToString();

        return cnpj.EndsWith(verificationDigits);

    }

    public static bool IsCpf(string cpf)
    {
        var firstMultiplier = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var secondMultiplier = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string cleanedCpf;
        string verificationDigits;

        int sum;
        int remainder;

        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
        {
            return false;
        }

        cleanedCpf = cpf.Substring(0, 9);
        sum = 0;

        for (int i = 0; i < 9; i++)
        {
            sum += int.Parse(cleanedCpf[i].ToString()) * firstMultiplier[i];
        }

        remainder = sum % 11;

        if (remainder < 2)
        {
            remainder = 0;
        }
        else
        {
            remainder = 11 - remainder;
        }

        verificationDigits = remainder.ToString();
        cleanedCpf = cleanedCpf + verificationDigits;
        sum = 0;

        for (int i = 0; i < 10; i++)
        {
            sum += int.Parse(cleanedCpf[i].ToString()) * secondMultiplier[i];
        }

        remainder = sum % 11;

        if (remainder < 2)
        {
            remainder = 0;
        }
        else
        {
            remainder = 11 - remainder;
        }

        verificationDigits = verificationDigits + remainder.ToString();

        return cpf.EndsWith(verificationDigits);
    }
}
