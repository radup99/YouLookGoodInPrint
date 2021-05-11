using System;
using System.Collections.Generic;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Shared.Entities;

namespace YouLookGoodInPrint.Client
{
    public class PaymentsContainer
    {
        private List<Payment> _payments = new List<Payment>();

        private Payment _currentPayment = new Payment("", "", "", 0.5);
        private bool _noPaymentSelected = true;

        public List<Payment> Payments
        {
            get => _payments;
            set
            {
                _payments = value;
                NotifyStateChanged();
            }
        }

        public Payment CurrentPayment
        {
            get => _currentPayment;
            set
            {
                _currentPayment = value;
                NotifyStateChanged();
            }
        }

        public bool NoPaymentSelected
        {
            get => _noPaymentSelected;
            set
            {
                _noPaymentSelected = value;
                NotifyStateChanged();
            }
        }

        public void Clear()
        {
            Payments = null;
            NotifyStateChanged();
        }

        public Payment GetById(string id)
        {
            foreach (Payment pay in Payments)
                if (pay.Id == id)
                {
                    return pay;
                }

            return new Payment("" , "", "", 0.15);
        }

        public void SelectPayment(Payment payment)
        {
            this.CurrentPayment = payment;
            NotifyStateChanged();
        }

        public void DeletePayment(string id)
        {
            foreach(Payment pay in Payments)
                if (pay.Id == id)
                {
                    Payments.Remove(pay);
                    NotifyStateChanged();
                }
        }

        public double PriceSum()
        {
            double sum = 0;
            foreach (Payment pay in Payments)
                sum += pay.Price;

            return sum;
        }

        public void DeletePayment(Payment payment)
        {
            Payments.Remove(payment);
            NotifyStateChanged();
        }

        public void AddPayment(Payment payment)
        {
            Payments.Add(payment);
            NotifyStateChanged();
        }

        public void SortByName()
        {
            Payments.Sort((x, y) => string.Compare(x.DocumentTitle, y.DocumentTitle));
        }

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }

}
