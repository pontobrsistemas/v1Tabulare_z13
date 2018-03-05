<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/supervisor.master" autoeventwireup="true" inherits="supervisor_bloqueioDDD, App_Web_scj44z0b" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h1>
                Bloqueio de DDD
            </h1>
            <fieldset class="fieldset_l">
                <legend>Dados do DDD</legend>
                <div class="div_padrao">
                    <table align="left" class="style10">
                        <tr>
                            <td class="style14">
                                <asp:Label ID="lblCampanha" runat="server" CssClass="label" Text="Campanha:"></asp:Label>
                                <asp:DropDownList ID="dropCampanha" runat="server" AutoPostBack="True" CssClass="dropdown"
                                    OnSelectedIndexChanged="dropCampanha_SelectedIndexChanged" Width="344px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style14">

                                <fieldset class="fieldset_atendimento"> 
                                    <legend>DDD</legend>
                                    <div class="div_padrao">
                                        <asp:CheckBoxList ID="chkDDD" CssClass="chekBoxList" runat="server" RepeatColumns="9"
                                            RepeatDirection="Horizontal" Width="795px">
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                            <asp:ListItem>21</asp:ListItem>
                                            <asp:ListItem>22</asp:ListItem>
                                            <asp:ListItem>23</asp:ListItem>
                                            <asp:ListItem>24</asp:ListItem>
                                            <asp:ListItem>25</asp:ListItem>
                                            <asp:ListItem>26</asp:ListItem>
                                            <asp:ListItem>27</asp:ListItem>
                                            <asp:ListItem>28</asp:ListItem>
                                            <asp:ListItem>29</asp:ListItem>
                                            <asp:ListItem>31</asp:ListItem>
                                            <asp:ListItem>32</asp:ListItem>
                                            <asp:ListItem>33</asp:ListItem>
                                            <asp:ListItem>34</asp:ListItem>
                                            <asp:ListItem>35</asp:ListItem>
                                            <asp:ListItem>36</asp:ListItem>
                                            <asp:ListItem>37</asp:ListItem>
                                            <asp:ListItem>38</asp:ListItem>
                                            <asp:ListItem>39</asp:ListItem>
                                            <asp:ListItem>41</asp:ListItem>
                                            <asp:ListItem>42</asp:ListItem>
                                            <asp:ListItem>43</asp:ListItem>
                                            <asp:ListItem>44</asp:ListItem>
                                            <asp:ListItem>45</asp:ListItem>
                                            <asp:ListItem>46</asp:ListItem>
                                            <asp:ListItem>47</asp:ListItem>
                                            <asp:ListItem>48</asp:ListItem>
                                            <asp:ListItem>49</asp:ListItem>
                                            <asp:ListItem>51</asp:ListItem>
                                            <asp:ListItem>52</asp:ListItem>
                                            <asp:ListItem>53</asp:ListItem>
                                            <asp:ListItem>54</asp:ListItem>
                                            <asp:ListItem>55</asp:ListItem>
                                            <asp:ListItem>56</asp:ListItem>
                                            <asp:ListItem>57</asp:ListItem>
                                            <asp:ListItem>58</asp:ListItem>
                                            <asp:ListItem>59</asp:ListItem>
                                            <asp:ListItem>61</asp:ListItem>
                                            <asp:ListItem>62</asp:ListItem>
                                            <asp:ListItem>63</asp:ListItem>
                                            <asp:ListItem>64</asp:ListItem>
                                            <asp:ListItem>65</asp:ListItem>
                                            <asp:ListItem>66</asp:ListItem>
                                            <asp:ListItem>67</asp:ListItem>
                                            <asp:ListItem>68</asp:ListItem>
                                            <asp:ListItem>69</asp:ListItem>
                                            <asp:ListItem>71</asp:ListItem>
                                            <asp:ListItem>72</asp:ListItem>
                                            <asp:ListItem>73</asp:ListItem>
                                            <asp:ListItem>74</asp:ListItem>
                                            <asp:ListItem>75</asp:ListItem>
                                            <asp:ListItem>76</asp:ListItem>
                                            <asp:ListItem>77</asp:ListItem>
                                            <asp:ListItem>78</asp:ListItem>
                                            <asp:ListItem>79</asp:ListItem>
                                            <asp:ListItem>81</asp:ListItem>
                                            <asp:ListItem>82</asp:ListItem>
                                            <asp:ListItem>83</asp:ListItem>
                                            <asp:ListItem>84</asp:ListItem>
                                            <asp:ListItem>85</asp:ListItem>
                                            <asp:ListItem>86</asp:ListItem>
                                            <asp:ListItem>87</asp:ListItem>
                                            <asp:ListItem>88</asp:ListItem>
                                            <asp:ListItem>89</asp:ListItem>
                                            <asp:ListItem>91</asp:ListItem>
                                            <asp:ListItem>92</asp:ListItem>
                                            <asp:ListItem>93</asp:ListItem>
                                            <asp:ListItem>94</asp:ListItem>
                                            <asp:ListItem>95</asp:ListItem>
                                            <asp:ListItem>96</asp:ListItem>
                                            <asp:ListItem>97</asp:ListItem>
                                            <asp:ListItem>98</asp:ListItem>
                                            <asp:ListItem>99</asp:ListItem>
                                            </asp:CheckBoxList>
                                </fieldset>
                                </tr>
                </div>
                </td> 
                <tr>
                    <td height="15">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        <asp:Button ID="cmdSalvar" runat="server" CssClass="botao" Text="Salvar" Width="83px"
                            OnClick="cmdSalvar_Click" />
                        &nbsp;<asp:Button ID="cmdCancelar" runat="server" CssClass="botao" Text="Cancelar"
                            Width="83px" />
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        &nbsp;
                    </td>
                </tr>
    
            </fieldset> 
            <fieldset class="fieldset_l">

            <div class="div_padrao">
                <table class="style30">
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblRegistros" runat="server" CssClass="label_descricao" Text="| 0 registro(s) |"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            <asp:GridView ID="dgDDD" runat="server" AutoGenerateColumns="False" CssClass="grid"
                                EnableModelValidation="True" DataKeyNames="Cód. Campanha" Style="text-align: left"
                                OnRowDataBound="dgDDD_RowDataBound">
                                <PagerStyle CssClass="grid_page" />
                                <RowStyle CssClass="grid" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:BoundField DataField="Campanha" HeaderText="Campanha" />
                                    <asp:BoundField DataField="Campanha" HeaderText="DDD" />
                                    <%--<asp:BoundField DataField="Data Cadastro" HeaderText="Data Cadastro" />
                                    <asp:BoundField DataField="Usuário do Sistema" HeaderText="Usuário do Sistema" />--%>
                                </Columns>
                                <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                                <AlternatingRowStyle CssClass="grid_alternative_row" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            </fieldset>
            <div class="clear"> </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
