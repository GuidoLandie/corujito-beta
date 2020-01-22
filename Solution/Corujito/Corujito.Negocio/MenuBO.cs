using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corujito.Entidade;

namespace Corujito.Negocio
{
    public class MenuBO
    {
        private List<MenuItem> Escola { get; set; }

        private List<MenuItem> Administracao { get; set; }

        private List<MenuItem> MinhaArea { get; set; }

        private List<MenuItem> MinhaAreaPai { get; set; }



        private void AddMenuItemEscola(MenuItem Item)
        {
            if (Escola == null)
            {
                Escola = new List<MenuItem>();
            }

            int i = IndexAplicacao(Escola, Item.Item.IdAplicacao);

            if (i < 0)
            {
                Escola.Add(Item);
            }
            else
            {
                Escola[i].SubItem.Add(Item);
            }

        }

        private void AddMenuItemAdministracao(MenuItem Item)
        {
            if (Administracao == null)
            {
                Administracao = new List<MenuItem>();
            }

            int i = IndexAplicacao(Administracao, Item.Item.IdAplicacao);

            if (i < 0)
            {
                Administracao.Add(Item);
            }
            else
            {
                if (Item.SubItem.Count > 0)
                {
                    Administracao[i].SubItem.Add(Item.SubItem[0]);
                }
            }
        }

        private void AddMenuItemMinhaArea(MenuItem Item)
        {
            if (MinhaArea == null)
            {
                MinhaArea = new List<MenuItem>();
            }

            int i = IndexAplicacao(MinhaArea, Item.Item.IdAplicacao);

            if (i < 0)
            {
                MinhaArea.Add(Item);
            }
            else
            {
                MinhaArea[i].SubItem.Add(Item);
            }
        }

        private void AddMenuItemMinhaAreaPai(MenuItem Item)
        {
            if (MinhaAreaPai == null)
            {
                MinhaAreaPai = new List<MenuItem>();
            }

            int i = IndexAplicacao(MinhaAreaPai, Item.Item.IdAplicacao);

            if (i < 0)
            {
                MinhaAreaPai.Add(Item);
            }
            else
            {
                MinhaAreaPai[i].SubItem.Add(Item);
            }
        }



        private int IndexAplicacao(List<MenuItem> objMenu, int IdAplicacao)
        {
            for (int i = 0; i < objMenu.Count; i++)
            {
                if (objMenu[i].Item.IdAplicacao == IdAplicacao)
                    return i;
                
                else if (objMenu[i].Item.IdAplicacao == Menu.Escola)
                    return 0;
                
                else if (objMenu[i].Item.IdAplicacao == Menu.Administracao)
                    return 0;
                
                else if (objMenu[i].Item.IdAplicacao == Menu.MinhaArea)
                    return 0;
                
                else if (objMenu[i].Item.IdAplicacao == Menu.MinhaAreaPai)
                    return 0;
            }

            return -1;
        }


        private Aplicacao FindPai(Aplicacao Filha)
        {
            if (Filha.AplicacaoPai != null)
                return FindPai(Filha.AplicacaoPai);

            return Filha;
        }

        private MenuItem NewMenuItem(Aplicacao Item)
        {
            MenuItem objMenuItem = new MenuItem();

            if (Item.AplicacaoPai == null)
            {
                objMenuItem.Item = Item;
                objMenuItem.SubItem = null;
            }
            else if (Item.AplicacaoPai.IdAplicacao > 4)
            {
                objMenuItem.Item = Item.AplicacaoPai;
                objMenuItem.SubItem = new List<MenuItem>();

                Item.AplicacaoPai = null;

                objMenuItem.SubItem.Add(NewMenuItem(Item));
            }
            else
            {
                Item.AplicacaoPai = null;
                return NewMenuItem(Item);
            }
          

            return objMenuItem;

        }

        public void AddAplication(Aplicacao Item)
        {
            Aplicacao Pai = FindPai(Item);

            MenuItem objMenuItem = NewMenuItem(Item);

            //Verifica quem eh este Pai
            if (Pai.IdAplicacao == Menu.Escola)
            {
                AddMenuItemEscola(objMenuItem);
            }
            else if (Pai.IdAplicacao == Menu.Administracao)
            {
                AddMenuItemAdministracao(objMenuItem);
            }
            else if (Pai.IdAplicacao == Menu.MinhaArea)
            {
                AddMenuItemMinhaArea(objMenuItem);
            }
            else if (Pai.IdAplicacao == Menu.MinhaAreaPai)
            {
                AddMenuItemMinhaAreaPai(objMenuItem);
            }
        }


        private string MenuItemToString(List<MenuItem> Items)
        {
            string str = string.Empty;

            if (Items.Count > 0)
            {
                str += "<ul>";

                foreach (MenuItem item in Items)
                {
                    str += "<li>";
                    str += item.Item.Caminho;
                    
                    if (item.SubItem != null && item.SubItem.Count > 0)
                    { 
                        str += MenuItemToString(item.SubItem);
                    }
                    
                    str += "</li>";
                }

                str += "</ul>";
            }

            return str;
        }

        public string ToString()
        {
            string strHtmlMenu = string.Empty;

            strHtmlMenu += "<ul>";

            //----------------------------------------------------------
            if (Escola != null)
            {
                strHtmlMenu += "<li>";

                strHtmlMenu += (new AplicacaoBO().CaminhoAplicacao(Menu.Escola));

                if (Escola.Count > 0)
                {
                    strHtmlMenu += MenuItemToString(Escola);
                }

                strHtmlMenu += "</li>";
            }

            //-----------------------------------------------------------------
            if (Administracao != null)
            {
                strHtmlMenu += "<li>";

                strHtmlMenu += (new AplicacaoBO().CaminhoAplicacao(Menu.Administracao));

                if (Administracao.Count > 0)
                {
                    strHtmlMenu += MenuItemToString(Administracao);
                }

                strHtmlMenu += "</li>";
            }

            //---------------------------------------------------------------
            if (MinhaArea != null)
            {
                strHtmlMenu += "<li>";

                strHtmlMenu += (new AplicacaoBO().CaminhoAplicacao(Menu.MinhaArea));

                if (MinhaArea.Count > 0)
                {
                    strHtmlMenu += MenuItemToString(MinhaArea);
                }

                strHtmlMenu += "</li>";
            }

            //---------------------------------------------------------------
            if (MinhaAreaPai != null)
            {
                strHtmlMenu += "<li>";

                strHtmlMenu += (new AplicacaoBO().CaminhoAplicacao(Menu.MinhaAreaPai));

                if (MinhaAreaPai.Count > 0)
                {
                    strHtmlMenu += MenuItemToString(MinhaAreaPai);
                }

                strHtmlMenu += "</li>";
            }





            strHtmlMenu += "</ul>";



            return strHtmlMenu;
        }
    }
}
