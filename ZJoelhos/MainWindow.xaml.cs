using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ZJoelhos.Entities;

namespace ZJoelhos
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Pedido> Pedidos { get; set; }
        private int nextPedidoId = 1;
        private int nextClienteId = 1;
        private int nextJoelhoId = 1;

        public MainWindow()
        {
            InitializeComponent();
            Pedidos = new ObservableCollection<Pedido>();
            PedidosListView.ItemsSource = Pedidos;
        }

        private void AdicionarPedidoButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ClienteTextBox.Text) || string.IsNullOrWhiteSpace(JoelhoComboBox.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            var cliente = new Clientes(nextClienteId++, ClienteTextBox.Text);
            var joelho = new Joelhos(nextJoelhoId++, JoelhoComboBox.Text, ObservacaoTextBox.Text);
            var novoPedido = new Pedido(nextPedidoId++, cliente, joelho);

            Pedidos.Add(novoPedido);

            // Limpar os campos após adicionar o pedido
            ClienteTextBox.Clear();
            JoelhoComboBox.SelectedIndex = -1;
            ObservacaoTextBox.Clear();
        }

        private void Totalizador_Click()
        {
            var totalPorSabor = Pedidos.GroupBy(p => p.Joelho.Sabor)
                                       .Select(g => new { Sabor = g.Key, Total = g.Count() })
                                       .OrderByDescending(x => x.Total);

            StringBuilder mensagem = new StringBuilder("Total de Joelhos por Sabor:\n\n");
            foreach (var item in totalPorSabor)
            {
                mensagem.AppendLine($"{item.Sabor}: {item.Total}");
            }
        }

        private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                (sender as UIElement).MoveFocus(request);
            }
        }

        private void OnComboBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                (sender as UIElement).MoveFocus(request);
            }
        }

        private void RemoverPedidoButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var pedido = button.Tag as Pedido;

            MessageBoxResult result = MessageBox.Show("Tem certeza que deseja remover este pedido?", "Confirmar Remoção", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Pedidos.Remove(pedido);
            }
        }


    }
}
