- 글자수 제한설정

```csharp
MaxLength="" 사용

<dx:ASPxTextBox runat="server" ID="aPxTBxMatType" 
ClientIDMode="Static" CssClass="txt_search" **MaxLength="10"**>
</dx:ASPxTextBox>
```

- 숫자는 우측정렬
    - 글자수 제한설정 할필요없음
    - 3자리 마다 “ , “ 설정

```csharp
<script>

				function OnUserInput(s, e) {
            s.SetText(numberWithCommas(s.GetText().replace(/,/g, '')));
        }

        
        function numberWithCommas(x) {
            if(x != null)
                return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            else
                return "";            
        }

</script>

<ClientSideEvents UserInput="OnUserInput" />
```

- 날짜 디폴트 오늘로 설정

```csharp
<ClientSideEvents Init="function(s,e){ s.SetDate(new Date());}" />  사용

<dx:ASPxDateEdit ID="aPxDTEtBuyDate" runat="server" ClientIDMode="Static" CssClass="txt_search">
**<ClientSideEvents Init="function(s,e){ s.SetDate(new Date());}" />** 
 </dx:ASPxDateEdit>
```